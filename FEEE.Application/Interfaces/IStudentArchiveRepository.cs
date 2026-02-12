using FEEE.Application.DTOs.StudentArchive;
using FEEE.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FEEE.Domain.Interfaces
{
    public interface IStudentArchiveRepository
    {
        Task<List<StudentArchiveModel>> GetAllAsync(int pageNumber, int pageSize);
        Task<StudentArchiveModel?> GetByIdAsync(int id);
        Task<List<StudentArchiveModel>> GetByStudentIdAsync(int studentId);
        Task <int>AddAsync(StudentArchiveModel model);
        Task<List<StudentArchiveListResponse>> GetByOperationTypeAsync(int operationTypeId);
       

    }

}
