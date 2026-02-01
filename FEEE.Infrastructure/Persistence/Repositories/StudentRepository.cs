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

    }
}
