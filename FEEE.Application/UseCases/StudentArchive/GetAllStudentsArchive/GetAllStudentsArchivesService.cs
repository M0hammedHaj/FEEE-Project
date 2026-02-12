using FEEE.Application.DTOs.StudentArchive;
using FEEE.Application.Mappings.StudentArchive;
using FEEE.Domain.Entities;
using FEEE.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FEEE.Application.UseCases.StudentArchive.GetAllStudentsArchive
{
    public class GetAllStudentsArchivesService
    {
        private readonly IStudentArchiveRepository _repository;
        public GetAllStudentsArchivesService(IStudentArchiveRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<StudentArchiveResponse>> ExecuteAsync(int pageNumber, int pageSize)
        {
            var archives = await _repository.GetAllAsync(pageNumber, pageSize);
            return archives.Select(StudentArchiveMapper.ToResponse).ToList();
        }

    }
}
