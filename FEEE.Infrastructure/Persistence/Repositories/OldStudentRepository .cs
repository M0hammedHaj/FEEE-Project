using FEEE.Application.Interfaces;
using FEEE.Domain.Entities;
using FEEE.Infrastructure.Persistence.Context;
using FEEE.Infrastructure.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

namespace FEEE.Infrastructure.Persistence.Repositories
{
    public class OldStudentRepository : IOldStudentRepository
    {
        private readonly WinDbContext _context;

        public OldStudentRepository(WinDbContext context)
        {
            _context = context;
        }

        public async Task<List<OldStudent>> GetAllAsync()
        {
            return await _context.OldStudents
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<OldStudent?> GetByIdAsync(int id)
        {
            return await _context.OldStudents
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.ID == id);
        }
    }
}
