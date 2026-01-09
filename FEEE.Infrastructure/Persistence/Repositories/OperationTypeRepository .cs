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
    public class OperationTypeRepository : IOperationTypeRepository
    {
        private readonly AppDbContext _context;

        public OperationTypeRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<OperationTypeModel>> GetAllAsync()
        {
            return await _context.OperationTypes
                .Select(o => new OperationTypeModel
                {
                    OperationTypeId = o.OperationTypeId,
                    Name = o.Name
                })
                .ToListAsync();
        }

        public async Task<OperationTypeModel?> GetByIdAsync(int id)
        {
            return await _context.OperationTypes
                .Where(o => o.OperationTypeId == id)
                .Select(o => new OperationTypeModel
                {
                    OperationTypeId = o.OperationTypeId,
                    Name = o.Name
                })
                .FirstOrDefaultAsync();
        }
    }
}
