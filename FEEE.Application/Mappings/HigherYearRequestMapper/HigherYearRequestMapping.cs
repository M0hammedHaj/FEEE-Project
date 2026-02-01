using FEEE.Application.DTOs.HigherYearRequests;
using FEEE.Domain.Entities;
using FEEE.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FEEE.Application.Mappings.HigherYearRequestMapper
{
    public static class HigherYearRequestMapper
    {
        public static HigherYearRequestModel ToModel(this CreateHigherYearRequestDto dto)
        {
            return new HigherYearRequestModel
            {
                StudentId = dto.StudentId,
                YearId = dto.YearId,
                SectionId = dto.SectionId,
                SemesterId = dto.SemesterId,
                SubjectIds = dto.SelectedSubjectIds,
                Status = HigherYearRequestStatus.Pending,
                CreatedAt = DateTime.UtcNow
            };
        }

        public static CreateHigherYearRequestResponseDto ToCreateResponseDto(int requestId, HigherYearRequestStatus status)
        {
            return new CreateHigherYearRequestResponseDto
            {
                RequestId = requestId,
                Status = status.ToString().ToUpper(),
                CreatedAt = DateTime.UtcNow
            };
        }
    }
}
