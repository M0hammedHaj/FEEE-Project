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
                .Where(sp => sp.StudentPromotionId == id)
                .Select(sp => new StudentPromotionModel
                {
                    StudentPromotionId = sp.StudentPromotionId,
                    StudentId = sp.StudentId,
                    FromYearId = sp.FromYearId,
                    ToYearId = sp.ToYearId,
                    PromotionDate = sp.PromotionDate,
                    Decision = sp.Decision
                })
                .FirstOrDefaultAsync();
        }

        public async Task AddAsync(StudentPromotionModel model)
        {
            var entity = new Infrastructure.Persistence.Entities.StudentPromotion
            {
                StudentId = model.StudentId,
                FromYearId = model.FromYearId,
                ToYearId = model.ToYearId,
                PromotionDate = model.PromotionDate,
                Decision = model.Decision
            };

            _context.StudentPromotions.Add(entity);
            await _context.SaveChangesAsync();
        }
    }
}
