using FEEE.Domain.Models;
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
        Task AddAsync(CityModel model);
        Task UpdateAsync(CityModel model);
        Task DeleteAsync(int id);
    }
}
