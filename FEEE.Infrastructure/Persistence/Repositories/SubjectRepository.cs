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
    public class SubjectRepository : ISubjectRepository
    {
        private readonly AppDbContext _context;

        public SubjectRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<SubjectModel>> GetAllAsync()
        {
            return await _context.Subjects
                .Select(s => new SubjectModel
                {
                    SubjectId = s.SubjectId,
                    Name = s.Name,
                    Code = s.Code,
                    YearId = s.YearId,
                    HasPractical = s.HasPractical
                })
                .ToListAsync();
        }

        public async Task<SubjectModel?> GetByIdAsync(int id)
        {
            var subject = await _context.Subjects.FindAsync(id);
            if (subject == null) return null;

            return new SubjectModel
            {
                SubjectId = subject.SubjectId,
                Name = subject.Name,
                Code = subject.Code,
                YearId = subject.YearId,
                HasPractical = subject.HasPractical
            };
        }

        public async Task AddAsync(SubjectModel model)
        {
            _context.Subjects.Add(new Subject
            {
                Name = model.Name,
                Code = model.Code,
                YearId = model.YearId,
                HasPractical = model.HasPractical
            });

            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(SubjectModel model)
        {
            var subject = await _context.Subjects.FindAsync(model.SubjectId);
            if (subject == null) return;

            subject.Name = model.Name;
            subject.Code = model.Code;
            subject.YearId = model.YearId;
            subject.HasPractical = model.HasPractical;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var subject = await _context.Subjects.FindAsync(id);
            if (subject == null) return;

            _context.Subjects.Remove(subject);
            await _context.SaveChangesAsync();
        }
    }

}
