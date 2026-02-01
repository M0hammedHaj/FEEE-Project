using FEEE.Application.DTOs.Students;
using FEEE.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FEEE.Domain.Repositories
{
    public interface IStudentRepository
    {
        Task<IEnumerable<StudentModel>> GetAllAsync();
        Task<StudentModel?> GetByIdAsync(int id);
        Task<bool> ExistsAsync(int id);
        Task<int> AddAsync(StudentModel student);
        Task UpdateAsync(StudentModel student);
        Task DeleteAsync(int id);
        Task<List<StudentSearchResponseDto>> SearchAsync(
            string? universityNumber,
            string? fullName);
    }
}
