using FEEE.Application.DTOs.Students;
using FEEE.Domain.Entities;
using FEEE.Domain.Enums;
using FEEE.Domain.Repositories;
using FEEE.Infrastructure.Persistence.Context;
using FEEE.Infrastructure.Persistence.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FEEE.Infrastructure.Persistence.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly AppDbContext _context;

        public StudentRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<StudentModel>> GetAllAsync()
        {
            return await _context.Students
                .Select(s => new StudentModel
                {
                    StudentId = s.StudentId,
                    UniversityNumber = s.UniversityNumber,
                    MinisterialNumber = s.MinisterialNumber, // ✅
                    FirstName = s.FirstName,
                    LastName = s.LastName,
                    FatherName = s.FatherName,
                    MotherName = s.MotherName,
                    BirthDate = s.BirthDate,
                    CityId = s.CityId,
                    SectionId = s.SectionId,
                    YearId = s.YearId,
                    Status = (StudentStatus)s.Status
                })
                .ToListAsync();
        }

        public async Task<StudentModel?> GetByIdAsync(int id)
        {
            var student = await _context.Students.FindAsync(id);

            if (student == null)
                return null;

            return new StudentModel
            {
                StudentId = student.StudentId,
                UniversityNumber = student.UniversityNumber,
                MinisterialNumber = student.MinisterialNumber,

                FirstName = student.FirstName,
                LastName = student.LastName,
                FatherName = student.FatherName,
                MotherName = student.MotherName,
                BirthDate = student.BirthDate,
                CityId = student.CityId,
                SectionId = student.SectionId,
                YearId = student.YearId,
                Status = (StudentStatus)student.Status
            };
        }

        public async Task <int>AddAsync(StudentModel model)
        {
            var entity = new Student
            {
                UniversityNumber = model.UniversityNumber,
                MinisterialNumber = model.MinisterialNumber,
                FirstName = model.FirstName,
                LastName = model.LastName,
                FatherName = model.FatherName,
                MotherName = model.MotherName,
                BirthDate = model.BirthDate,
                CityId = model.CityId,
                SectionId = model.SectionId,
                YearId = model.YearId,
                Status = (byte)model.Status   
            };

            _context.Students.Add(entity);
            await _context.SaveChangesAsync();
            return entity.StudentId;
        }

        public async Task UpdateAsync(StudentModel model)
        {
            var entity = await _context.Students.FindAsync(model.StudentId);
            if (entity == null)
                return;

            entity.UniversityNumber = model.UniversityNumber;
            entity.MinisterialNumber = model.MinisterialNumber;

            entity.FirstName = model.FirstName;
            entity.LastName = model.LastName;
            entity.FatherName = model.FatherName;
            entity.MotherName = model.MotherName;
            entity.BirthDate = model.BirthDate;
            entity.CityId = model.CityId;
            entity.SectionId = model.SectionId;
            entity.YearId = model.YearId;
            entity.Status = (byte)model.Status; 

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.Students.FindAsync(id);

            if (entity == null)
                return;

            _context.Students.Remove(entity);
            await _context.SaveChangesAsync();

        }

        public async Task<List<StudentSearchResponseDto>> SearchAsync(
                         string? universityNumber,
                         string? fullName)
        {
            var query = _context.Students.AsQueryable();

            if (!string.IsNullOrWhiteSpace(universityNumber))
                query = query.Where(x =>
                    x.UniversityNumber.Contains(universityNumber));

            if (!string.IsNullOrWhiteSpace(fullName))
                query = query.Where(x =>
                    (x.FirstName + " " + x.LastName)
                        .Contains(fullName));

            return await query
                .Select(x => new StudentSearchResponseDto
                {
                    StudentId = x.StudentId,
                    UniversityNumber = x.UniversityNumber,
                    FullName = x.FirstName + " " + x.LastName,
                    Status = (int)x.Status
                })
                .ToListAsync();
        }
        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.Students.AnyAsync(s => s.StudentId == id);
        }


        public async Task<List<StudentModel>> SearchStudentsAsync(string searchTerm, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return new List<StudentModel>();

            var normalizedSearch = NormalizeInput(searchTerm);
            var parts = normalizedSearch.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            IQueryable<Student> query = _context.Students
                .AsNoTracking();

            // أول شي: بحث بالرقم الجامعي أو الوزاري
            query = query.Where(s =>
                s.UniversityNumber == normalizedSearch ||
                s.MinisterialNumber == normalizedSearch);

            // إذا كان اسمين: الأول + الأخير
            if (parts.Length == 2)
            {
                string firstName = parts[0];
                string lastName = parts[1];

                query = query.Union(
                    _context.Students
                        .AsNoTracking()
                        .Where(s =>
                            s.FirstName != null &&
                            s.LastName != null &&
                            s.FirstName.Trim() == firstName &&
                            s.LastName.Trim() == lastName)
                );
            }

            // إذا كان 3 أسماء: الأول + الأب + الأخير أو الأول + الأم + الأخير
            else if (parts.Length == 3)
            {
                string firstName = parts[0];
                string middleName = parts[1];
                string lastName = parts[2];

                query = query.Union(
                    _context.Students
                        .AsNoTracking()
                        .Where(s =>
                            s.FirstName != null &&
                            s.LastName != null &&
                            s.FirstName.Trim() == firstName &&
                            s.LastName.Trim() == lastName &&
                            (
                                (s.FatherName != null && s.FatherName.Trim() == middleName) ||
                                (s.MotherName != null && s.MotherName.Trim() == middleName)
                            ))
                );
            }

            // إذا أكثر من 3 كلمات، حالياً منرجّع فاضي
            else if (parts.Length > 3)
            {
                return new List<StudentModel>();
            }

            return await query
                .Select(s => new StudentModel
                {
                    StudentId = s.StudentId,
                    UniversityNumber = s.UniversityNumber,
                    MinisterialNumber = s.MinisterialNumber,
                    FirstName = s.FirstName,
                    LastName = s.LastName,
                    FatherName = s.FatherName,
                    MotherName = s.MotherName,
                    BirthDate = s.BirthDate,
                    CityId = s.CityId,
                    SectionId = s.SectionId,
                    YearId = s.YearId,
                    Status =(StudentStatus)s.Status
                })
                .Distinct()
                .ToListAsync(cancellationToken);
        }

        private static string NormalizeInput(string input)
        {
            input = input.Trim();
            input = Regex.Replace(input, @"\s+", " ");
            return input;
        }










    }
}
