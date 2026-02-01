using FEEE.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FEEE.Domain.Interfaces
{
    public interface IStudentPromotionRepository
    {
        Task<List<StudentPromotionModel>> GetAllAsync();
        Task<StudentPromotionModel?> GetByIdAsync(int id);
        Task<List<StudentPromotionModel>> GetByStudentIdAsync(int studentId);
        Task <int>AddAsync(StudentPromotionModel model);
    }

}
