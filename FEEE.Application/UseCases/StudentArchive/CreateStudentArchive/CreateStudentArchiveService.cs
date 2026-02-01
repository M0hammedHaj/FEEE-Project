using FEEE.Application.DTOs.StudentArchive;
using FEEE.Application.Mappings.StudentArchive;
using FEEE.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FEEE.Application.UseCases.StudentArchive.CreateStudentArchive
{
    public class CreateStudentArchiveService
    {
        private readonly IStudentArchiveRepository _repository;

        public CreateStudentArchiveService(IStudentArchiveRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> ExecuteAsync(CreateStudentArchiveRequest request)
        {
            var model = StudentArchiveMapper.ToModel(request);
          var id =  await _repository.AddAsync(model);
            return id;
        }
    }

}
