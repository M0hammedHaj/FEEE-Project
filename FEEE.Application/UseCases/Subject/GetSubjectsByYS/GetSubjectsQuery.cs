using FEEE.Application.DTOs.Subject;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FEEE.Application.UseCases.Subject.GetSubjectsByYS
{
    public class GetSubjectsQuery : IRequest<List<SubjectResponseDto>>
    {
        public int SectionId { get; init; }
        public int YearId { get; init; }
        public int SemesterId { get; init; }
    }
}
