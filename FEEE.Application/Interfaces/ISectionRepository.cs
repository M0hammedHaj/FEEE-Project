using FEEE.Domain.Entities;
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
        Task <int>AddAsync(SectionModel model);
        Task UpdateAsync(SectionModel model);
        Task DeleteAsync(int id);
    }
}
