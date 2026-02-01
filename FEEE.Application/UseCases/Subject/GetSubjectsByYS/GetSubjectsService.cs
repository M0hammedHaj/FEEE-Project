using FEEE.Application.DTOs.Subject;
using FEEE.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FEEE.Application.UseCases.Subject.GetSubjectsByYS
{
    public class GetSubjectsService
     : IRequestHandler<GetSubjectsQuery, List<SubjectResponseDto>>
    {
        private readonly ISubjectRepository _subjectRepository;

        public GetSubjectsService(ISubjectRepository subjectRepository)
        {
            _subjectRepository = subjectRepository;
        }

        public async Task<List<SubjectResponseDto>> Handle(
            GetSubjectsQuery request,
            CancellationToken cancellationToken)
        {
            return await _subjectRepository.GetByFiltersAsync(
                request.SectionId,
                request.YearId,
                request.SemesterId);
        }
    }
}
