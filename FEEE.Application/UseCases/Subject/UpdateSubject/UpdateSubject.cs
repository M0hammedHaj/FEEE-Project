using FEEE.Application.DTOs.Subject;
using FEEE.Application.Mappings.Subject;
using FEEE.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FEEE.Application.UseCases.Subject.UpdateSubject
{
    public class UpdateSubjectService
    {
        private readonly ISubjectRepository _repository;

        public UpdateSubjectService(ISubjectRepository repository)
        {
            _repository = repository;
        }

        public async Task ExecuteAsync(UpdateSubjectRequest request)
        {
            var subject = await _repository.GetByIdAsync(request.SubjectId);
            if (subject == null)
                throw new Exception("Subject not found");

            SubjectMapper.UpdateModel(subject, request);
            await _repository.UpdateAsync(subject);
        }
    }

}
