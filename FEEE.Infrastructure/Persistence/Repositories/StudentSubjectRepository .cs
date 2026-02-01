using FEEE.Domain.Interfaces;
using FEEE.Domain.Entities;
using FEEE.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using FEEE.Infrastructure.Persistence.Context;

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
                    YearId = ss.YearId,
                    Semester = ss.Semester,
                    Status = (StudentSubjectStatus)ss.Status
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
                    YearId = ss.YearId,
                    Semester = ss.Semester,
                    Status = (StudentSubjectStatus)ss.Status
                })
                .FirstOrDefaultAsync();
        }

        public async Task AddAsync(StudentSubjectModel model)
        {
            var entity = new Infrastructure.Persistence.Models.StudentSubject
            {
                StudentId = model.StudentId,
                SubjectId = model.SubjectId,
                YearId = model.YearId,
                Semester = model.Semester,
                Status = (byte)model.Status
            };

            _context.StudentSubjects.Add(entity);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateStatusAsync(StudentSubjectModel model)
        {
            var entity = await _context.StudentSubjects
                .FirstOrDefaultAsync(x => x.StudentSubjectId == model.StudentSubjectId);

            if (entity == null)
                return;

            entity.Status = (byte)model.Status;
            await _context.SaveChangesAsync();
        }
        public async Task<List<StudentSubjectModel>> GetByStudentIdAsync(int studentId)
        {
            return await _context.StudentSubjects
                .Where(ss => ss.StudentId == studentId)
                .Select(ss => new StudentSubjectModel
                {
                    StudentSubjectId = ss.StudentSubjectId,
                    StudentId = ss.StudentId,
                    SubjectId = ss.SubjectId,
                    YearId = ss.YearId,
                    Semester = ss.Semester,
                    Status = (StudentSubjectStatus)ss.Status
                })
                .ToListAsync();
        }
    }
}
