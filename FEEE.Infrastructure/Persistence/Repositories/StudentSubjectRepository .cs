using FEEE.Domain.Interfaces;
using FEEE.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FEEE.Infrastructure.Persistence.Repositories
{
    public class StudentSubjectRepository : IStudentSubjectRepository
    {
        private readonly AppDbContext _context;

        public StudentSubjectRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<StudentSubjectModel>> GetAllAsync()
        {
            return await _context.StudentSubjects
                .Select(ss => new StudentSubjectModel
                {
                    StudentSubjectId = ss.StudentSubjectId,
                    StudentId = ss.StudentId,
                    SubjectId = ss.SubjectId,
                    AcademicYear = ss.AcademicYear,
                    Semester = ss.Semester,
                    Status = ss.Status
                })
                .ToListAsync();
        }

        public async Task<StudentSubjectModel?> GetByIdAsync(int id)
        {
            return await _context.StudentSubjects
                .Where(ss => ss.StudentSubjectId == id)
                .Select(ss => new StudentSubjectModel
                {
                    StudentSubjectId = ss.StudentSubjectId,
                    StudentId = ss.StudentId,
                    SubjectId = ss.SubjectId,
                    AcademicYear = ss.AcademicYear,
                    Semester = ss.Semester,
                    Status = ss.Status
                })
                .FirstOrDefaultAsync();
        }

        public async Task AddAsync(StudentSubjectModel model)
        {
            var entity = new Infrastructure.Persistence.Entities.StudentSubject
            {
                StudentId = model.StudentId,
                SubjectId = model.SubjectId,
                AcademicYear = model.AcademicYear,
                Semester = model.Semester,
                Status = model.Status
            };

            _context.StudentSubjects.Add(entity);
            await _context.SaveChangesAsync();
        }
    }
}
