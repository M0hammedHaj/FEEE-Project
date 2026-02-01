using FEEE.Domain.Entities;
using FEEE.Domain.Interfaces;
using FEEE.Infrastructure.Persistence.Context;
using FEEE.Infrastructure.Persistence.Models;
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



        public async Task<int> AddAsync(OperationTypeModel model)
        {
            var entity = new OperationType
            {
                OperationTypeId = model.OperationTypeId,
                Name = model.Name
            };

            await _context.OperationTypes.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity.OperationTypeId;
            
        }


        public async Task UpdateAsync(OperationTypeModel model)
        {
            var entity = await _context.OperationTypes
                .FirstOrDefaultAsync(o => o.OperationTypeId == model.OperationTypeId);

            if (entity == null)
                return;

            entity.Name = model.Name;

            await _context.SaveChangesAsync();
        }


        public async Task DeleteAsync(int id)
        {
            var entity = await _context.OperationTypes.FindAsync(id);
            if (entity == null)
                return;

            _context.OperationTypes.Remove(entity);
            await _context.SaveChangesAsync();
        }




    }
}
