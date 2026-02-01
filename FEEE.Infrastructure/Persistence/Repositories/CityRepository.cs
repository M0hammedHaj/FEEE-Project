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
    public class CityRepository : ICityRepository
    {
        private readonly AppDbContext _context;

        public CityRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CityModel>> GetAllAsync()
        {
            return await _context.Cities
                .Select(c => new CityModel
                {
                    CityId = c.CityId,
                    Name = c.Name
                })
                .ToListAsync();
        }

        public async Task<CityModel?> GetByIdAsync(int id)
        {
            var city = await _context.Cities.FindAsync(id);
            if (city == null) return null;

            return new CityModel
            {
                CityId = city.CityId,
                Name = city.Name
            };
        }

        public async Task<int> AddAsync(CityModel model)
        {
           var entity = new City
           {
                Name = model.Name
            };
            _context.Cities.Add(entity);
            await _context.SaveChangesAsync();
            return entity.CityId;
        }

        public async Task UpdateAsync(CityModel model)
        {
            var city = await _context.Cities.FindAsync(model.CityId);
            if (city == null) return;

            city.Name = model.Name;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var city = await _context.Cities.FindAsync(id);
            if (city == null) return;

            _context.Cities.Remove(city);
            await _context.SaveChangesAsync();
        }
    }
}
