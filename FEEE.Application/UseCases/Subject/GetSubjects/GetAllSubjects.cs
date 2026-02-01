using FEEE.Application.DTOs.Subject;
using FEEE.Application.Mappings.Subject;
using FEEE.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FEEE.Application.UseCases.Subject.GetSubjects
{
    public class GetAllSubjectsService
    {
        private readonly ISubjectRepository _repository;

        public GetAllSubjectsService(ISubjectRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<SubjectResponse>> ExecuteAsync()
        {
            var subjects = await _repository.GetAllAsync();
            return subjects.Select(SubjectMapper.ToResponse).ToList();
        }
    }

}
