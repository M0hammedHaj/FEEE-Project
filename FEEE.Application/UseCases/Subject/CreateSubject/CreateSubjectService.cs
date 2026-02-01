using FEEE.Application.DTOs.Subject;
using FEEE.Application.Mappings.Subject;
using FEEE.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FEEE.Application.UseCases.Subject.CreateSubject
{
    public class CreateSubjectService
    {
        private readonly ISubjectRepository _repository;

        public CreateSubjectService(ISubjectRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> ExecuteAsync(CreateSubjectRequest request)
        {
            var model = SubjectMapper.ToModel(request);
           var id =  await _repository.AddAsync(model);
            return id;
        }
    }

}
