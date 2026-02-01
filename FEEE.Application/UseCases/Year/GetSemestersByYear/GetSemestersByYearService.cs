using FEEE.Application.DTOs.Semesters;
using FEEE.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FEEE.Application.UseCases.Year.GetSemestersByYear
{
    public class GetSemestersByYearService
     : IRequestHandler<GetSemestersByYearQuery, List<SemesterResponseDto>>
    {
        private readonly ISemesterRepository _semesterRepository;

        public GetSemestersByYearService(
            ISemesterRepository semesterRepository)
        {
            _semesterRepository = semesterRepository;
        }

        public async Task<List<SemesterResponseDto>> Handle(
            GetSemestersByYearQuery request,
            CancellationToken cancellationToken)
        {
            return await _semesterRepository
                .GetByYearIdAsync(request.YearId);
        }
    }
}
