using FEEE.Application.DTOs.Semesters;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FEEE.Application.UseCases.Year.GetSemestersByYear
{
    public class GetSemestersByYearQuery : IRequest<List<SemesterResponseDto>>
    {
        public int YearId { get; }

        public GetSemestersByYearQuery(int yearId)
        {
            YearId = yearId;
        }
    }
}
