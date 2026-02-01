using FEEE.Application.DTOs.Semesters;
using FEEE.Application.Interfaces;
using FEEE.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FEEE.Infrastructure.Persistence.Repositories
{
    public class SemesterRepository : ISemesterRepository
    {
        private readonly AppDbContext _context;

        public SemesterRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<SemesterResponseDto>> GetByYearIdAsync(int yearId)
        {
            return await _context.Semesters
                .Where(x => x.YearId == yearId && x.IsActive)
                .OrderBy(x => x.Order)
                .Select(x => new SemesterResponseDto
                {
                    SemesterId = x.SemesterId,
                    Name = x.Name,
                    Order = x.Order
                })
                .ToListAsync();
        }
    }
}
