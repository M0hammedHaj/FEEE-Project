using FEEE.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FEEE.Domain.Interfaces
{
    public interface IStudentArchiveRepository
    {
        Task<List<StudentArchiveModel>> GetAllAsync();
        Task<StudentArchiveModel?> GetByIdAsync(int id);
        Task AddAsync(StudentArchiveModel model);
    }
}
