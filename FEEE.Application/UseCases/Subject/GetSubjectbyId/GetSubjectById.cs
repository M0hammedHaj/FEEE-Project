using FEEE.Application.DTOs.Subject;
using FEEE.Application.Mappings.Subject;
using FEEE.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FEEE.Application.UseCases.Subject.GetSubjectbyId
{
    public class GetSubjectByIdService
    {
        private readonly ISubjectRepository _repository;

        public GetSubjectByIdService(ISubjectRepository repository)
        {
            _repository = repository;
        }

        public async Task<SubjectResponse?> ExecuteAsync(int id)
        {
            var subject = await _repository.GetByIdAsync(id);
            return subject == null ? null : SubjectMapper.ToResponse(subject);
        }
    }

}
