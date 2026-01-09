using FEEE.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FEEE.Domain.Interfaces
{
    public interface IStudentSubjectRepository
    {
        Task<List<StudentSubjectModel>> GetAllAsync();
        Task<StudentSubjectModel?> GetByIdAsync(int id);
        Task AddAsync(StudentSubjectModel model);
    }
}
