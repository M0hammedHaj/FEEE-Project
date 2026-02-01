using FEEE.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FEEE.Domain.Interfaces
{
    public interface ICityRepository
    {
        Task<IEnumerable<CityModel>> GetAllAsync();
        Task<CityModel?> GetByIdAsync(int id);
        Task <int>AddAsync(CityModel model);
        Task UpdateAsync(CityModel model);
        Task DeleteAsync(int id);
    }
}
