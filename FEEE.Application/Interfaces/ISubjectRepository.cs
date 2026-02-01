using FEEE.Application.DTOs.Subject;
using FEEE.Domain.Entities;
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
        Task <int>AddAsync(SubjectModel model);
        Task UpdateAsync(SubjectModel model);
        Task DeleteAsync(int id);
        Task<List<SubjectResponseDto>> GetByFiltersAsync(
        int sectionId,
        int yearId,
        int semesterId);
    }
}
