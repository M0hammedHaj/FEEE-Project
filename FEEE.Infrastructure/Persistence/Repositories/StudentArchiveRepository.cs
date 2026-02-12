using FEEE.Domain.Interfaces;
using FEEE.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FEEE.Infrastructure.Persistence.Context;
using FEEE.Application.DTOs.StudentArchive;


namespace FEEE.Infrastructure.Persistence.Repositories
{
    public class StudentArchiveRepository : IStudentArchiveRepository
    {
        private readonly AppDbContext _context;

        public StudentArchiveRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<StudentArchiveModel>> GetAllAsync(int pageNumber, int pageSize)
        {
            return await _context.StudentArchives
        .OrderBy(sa => sa.StudentArchiveId)
        .Skip((pageNumber - 1) * pageSize)
        .Take(pageSize)
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
                .Where(x => x.StudentArchiveId == id)
                .Select(x => new StudentArchiveModel
                {
                    StudentArchiveId = x.StudentArchiveId,
                    ArchiveNumber = x.ArchiveNumber,
                    StudentId = x.StudentId,
                    OperationType = x.OperationType,
                    ArchiveDate = x.ArchiveDate,
                    Notes = x.Notes,
                    UserId = x.UserId
                })
                .FirstOrDefaultAsync();
        }


        public async Task<List<StudentArchiveModel>> GetByStudentIdAsync(int studentId)
        {
            return await _context.StudentArchives
                .Where(x => x.StudentId == studentId)
                .Select(x => new StudentArchiveModel
                {
                    StudentArchiveId = x.StudentArchiveId,
                    ArchiveNumber = x.ArchiveNumber,
                    StudentId = x.StudentId,
                    OperationType = x.OperationType,
                    ArchiveDate = x.ArchiveDate,
                    Notes = x.Notes,
                    UserId = x.UserId
                })
                .ToListAsync();
        }


        public async Task <int>AddAsync(StudentArchiveModel model)
        {
            var entity = new Infrastructure.Persistence.Models.StudentArchive
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
            return entity.StudentArchiveId;
        }
        public async Task<List<StudentArchiveListResponse>> GetByOperationTypeAsync(int operationTypeId)
        {
            return await _context.StudentArchives
                .Where(x => x.OperationType  == operationTypeId)
                .Select(x => new StudentArchiveListResponse
                {
                    ArchiveId = x.StudentArchiveId,
                    StudentName = x.Student.FirstName + ""+ x.Student.LastName,
                    UniversityNumber = x.Student.UniversityNumber,
                    MinisterialNumber = x.Student.MinisterialNumber, 
                    OperationType = x.OperationTypeNavigation.Name,
                    
                    CreatedAt = x.ArchiveDate,
                })
                .OrderByDescending(x => x.CreatedAt)
                .ToListAsync();
        }

    }
}
