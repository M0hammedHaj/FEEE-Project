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
    public class SectionRepository : ISectionRepository
    {
        private readonly AppDbContext _context;

        public SectionRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<SectionModel>> GetAllAsync()
        {
            return await _context.Sections
                .Select(s => new SectionModel
                {
                    SectionId = s.SectionId,
                    Name = s.Name,
                    Active = s.Active
                })
                .ToListAsync();
        }

        public async Task<SectionModel?> GetByIdAsync(int id)
        {
            var section = await _context.Sections.FindAsync(id);
            if (section == null) return null;

            return new SectionModel
            {
                SectionId = section.SectionId,
                Name = section.Name,
                Active = section.Active
            };
        }

        public async Task AddAsync(SectionModel model)
        {
            _context.Sections.Add(new Section
            {
                Name = model.Name,
                Active = model.Active
            });

            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(SectionModel model)
        {
            var section = await _context.Sections.FindAsync(model.SectionId);
            if (section == null) return;

            section.Name = model.Name;
            section.Active = model.Active;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var section = await _context.Sections.FindAsync(id);
            if (section == null) return;

            _context.Sections.Remove(section);
            await _context.SaveChangesAsync();
        }
    }
}
