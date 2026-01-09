using FEEE.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FEEE.Domain.Interfaces
{
    public interface ISectionRepository
    {
        Task<IEnumerable<SectionModel>> GetAllAsync();
        Task<SectionModel?> GetByIdAsync(int id);
        Task AddAsync(SectionModel model);
        Task UpdateAsync(SectionModel model);
        Task DeleteAsync(int id);
    }
}
