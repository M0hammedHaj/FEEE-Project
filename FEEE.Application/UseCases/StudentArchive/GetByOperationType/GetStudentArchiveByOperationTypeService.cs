using FEEE.Application.DTOs.StudentArchive;
using FEEE.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FEEE.Application.UseCases.StudentArchive.GetByOperationType
{
    public class GetStudentArchiveByOperationTypeService
    {
        private readonly IStudentArchiveRepository _repo;

        public GetStudentArchiveByOperationTypeService(IStudentArchiveRepository repo)
        {
            _repo = repo;
        }

        public async Task<List<StudentArchiveListResponse>> ExecuteAsync(int operationTypeId, int pageNumber, int pageSize)
        {
            return await _repo.GetByOperationTypeAsync(operationTypeId,  pageNumber,  pageSize);
        }
    }

}
