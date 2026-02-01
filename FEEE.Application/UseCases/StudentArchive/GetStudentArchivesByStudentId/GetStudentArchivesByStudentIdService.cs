using FEEE.Application.DTOs.StudentArchive;
using FEEE.Application.Mappings.StudentArchive;
using FEEE.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FEEE.Application.UseCases.StudentArchive.GetStudentArchivesByStudentId
{
    public class GetStudentArchivesByStudentIdService
    {
        private readonly IStudentArchiveRepository _repository;

        public GetStudentArchivesByStudentIdService(IStudentArchiveRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<StudentArchiveResponse>> ExecuteAsync(int studentId)
        {
            var items = await _repository.GetByStudentIdAsync(studentId);
            return items.Select(StudentArchiveMapper.ToResponse).ToList();
        }
    }

}
