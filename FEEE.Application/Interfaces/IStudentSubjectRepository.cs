using FEEE.Domain.Entities;
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
        Task UpdateStatusAsync(StudentSubjectModel model);
        Task<List<StudentSubjectModel>> GetByStudentIdAsync(int studentId);

    }
}
