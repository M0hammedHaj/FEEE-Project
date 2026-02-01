using FEEE.Domain.Interfaces;
using FEEE.Domain.Entities;
using FEEE.Infrastructure.Persistence.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FEEE.Infrastructure.Persistence.Context;

namespace FEEE.Infrastructure.Persistence.Repositories
{
    public class YearRepository : IYearRepository
    {
        private readonly AppDbContext _context;

        public YearRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<YearModel>> GetAllAsync()
        {
            return await _context.Years
                .Select(y => new YearModel
                {
                    YearId = y.YearId,
                    Name = y.Name
                })
                .ToListAsync();
        }

        public async Task<YearModel?> GetByIdAsync(int id)
        {
            var year = await _context.Years.FindAsync(id);
            if (year == null) return null;

            return new YearModel
            {
                YearId = year.YearId,
                Name = year.Name
            };
        }

        public async Task<int> AddAsync(YearModel model)
        {
            var entity = new Year
            {
                Name = model.Name
            };
            _context.Years.Add(entity);
            await _context.SaveChangesAsync();
            return entity.YearId;
        }

        public async Task UpdateAsync(YearModel model)
        {
            var year = await _context.Years.FindAsync(model.YearId);
            if (year == null) return;

            year.Name = model.Name;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var year = await _context.Years.FindAsync(id);
            if (year == null) return;

            _context.Years.Remove(year);
            await _context.SaveChangesAsync();
        }
    }
}
