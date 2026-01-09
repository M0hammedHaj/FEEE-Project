using FEEE.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FEEE.Domain.Interfaces
{
    public interface ISubjectRepository
    {
        Task<IEnumerable<SubjectModel>> GetAllAsync();
        Task<SubjectModel?> GetByIdAsync(int id);
        Task AddAsync(SubjectModel model);
        Task UpdateAsync(SubjectModel model);
        Task DeleteAsync(int id);
    }
}
