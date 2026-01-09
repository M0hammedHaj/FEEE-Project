using FEEE.Domain.Interfaces;
using FEEE.Domain.Models;
using FEEE.Infrastructure.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public async Task AddAsync(YearModel model)
        {
            _context.Years.Add(new Year
            {
                Name = model.Name
            });

            await _context.SaveChangesAsync();
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
