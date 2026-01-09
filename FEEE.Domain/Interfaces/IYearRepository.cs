using FEEE.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FEEE.Domain.Interfaces
{
    public interface IYearRepository
    {
        Task<IEnumerable<YearModel>> GetAllAsync();
        Task<YearModel?> GetByIdAsync(int id);
        Task AddAsync(YearModel model);
        Task UpdateAsync(YearModel model);
        Task DeleteAsync(int id);
    }
}
