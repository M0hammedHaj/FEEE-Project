using FEEE.Domain.Interfaces;
using FEEE.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FEEE.Infrastructure.Persistence.Context;

namespace FEEE.Infrastructure.Persistence.Repositories
{
    public class StudentPromotionRepository : IStudentPromotionRepository
    {
        private readonly AppDbContext _context;

        public StudentPromotionRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<StudentPromotionModel>> GetAllAsync()
        {
            return await _context.StudentPromotions
                .Select(sp => new StudentPromotionModel
                {
                    StudentPromotionId = sp.StudentPromotionId,
                    StudentId = sp.StudentId,
                    FromYearId = sp.FromYearId,
                    ToYearId = sp.ToYearId,
                    PromotionDate = sp.PromotionDate,
                    Decision = sp.Decision
                })
                .ToListAsync();
        }

        public async Task<StudentPromotionModel?> GetByIdAsync(int id)
        {
            return await _context.StudentPromotions
                .Where(x => x.StudentPromotionId == id)
                .Select(x => new StudentPromotionModel
                {
                    StudentPromotionId = x.StudentPromotionId,
                    StudentId = x.StudentId,
                    FromYearId = x.FromYearId,
                    ToYearId = x.ToYearId,
                    PromotionDate = x.PromotionDate,
                    Decision = x.Decision
                })
                .FirstOrDefaultAsync();
        }


        public async Task<List<StudentPromotionModel>> GetByStudentIdAsync(int studentId)
        {
            return await _context.StudentPromotions
                .Where(x => x.StudentId == studentId)
                .Select(x => new StudentPromotionModel
                {
                    StudentPromotionId = x.StudentPromotionId,
                    StudentId = x.StudentId,
                    FromYearId = x.FromYearId,
                    ToYearId = x.ToYearId,
                    PromotionDate = x.PromotionDate,
                    Decision = x.Decision
                })
                .ToListAsync();
        }




        public async Task<int> AddAsync(StudentPromotionModel model)
        {
            var entity = new Infrastructure.Persistence.Models.StudentPromotion
            {
                StudentId = model.StudentId,
                FromYearId = model.FromYearId,
                ToYearId = model.ToYearId,
                PromotionDate = model.PromotionDate,
                Decision = model.Decision
            };

            _context.StudentPromotions.Add(entity);
            await _context.SaveChangesAsync();
            return entity.StudentPromotionId;
        }
    }
}
