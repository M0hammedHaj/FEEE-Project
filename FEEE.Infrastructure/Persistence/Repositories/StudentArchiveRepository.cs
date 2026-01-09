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
    public class StudentArchiveRepository : IStudentArchiveRepository
    {
        private readonly AppDbContext _context;

        public StudentArchiveRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<StudentArchiveModel>> GetAllAsync()
        {
            return await _context.StudentArchives
                .Select(sa => new StudentArchiveModel
                {
                    StudentArchiveId = sa.StudentArchiveId,
                    ArchiveNumber = sa.ArchiveNumber,
                    StudentId = sa.StudentId,
                    OperationType = sa.OperationType,
                    ArchiveDate = sa.ArchiveDate,
                    Notes = sa.Notes,
                    UserId = sa.UserId
                })
                .ToListAsync();
        }

        public async Task<StudentArchiveModel?> GetByIdAsync(int id)
        {
            return await _context.StudentArchives
                .Where(sa => sa.StudentArchiveId == id)
                .Select(sa => new StudentArchiveModel
                {
                    StudentArchiveId = sa.StudentArchiveId,
                    ArchiveNumber = sa.ArchiveNumber,
                    StudentId = sa.StudentId,
                    OperationType = sa.OperationType,
                    ArchiveDate = sa.ArchiveDate,
                    Notes = sa.Notes,
                    UserId = sa.UserId
                })
                .FirstOrDefaultAsync();
        }

        public async Task AddAsync(StudentArchiveModel model)
        {
            var entity = new Infrastructure.Persistence.Entities.StudentArchive
            {
                ArchiveNumber = model.ArchiveNumber,
                StudentId = model.StudentId,
                OperationType = model.OperationType,
                ArchiveDate = model.ArchiveDate,
                Notes = model.Notes,
                UserId = model.UserId
            };

            _context.StudentArchives.Add(entity);
            await _context.SaveChangesAsync();
        }
    }
}
