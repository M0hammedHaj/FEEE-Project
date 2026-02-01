using FEEE.Application.DTOs.HigherYearRequests;
using FEEE.Application.Interfaces;
using FEEE.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FEEE.Application.UseCases.HigherYearRequests.UpdateHigherYearRequestService
{
    public class UpdateHigherYearRequestService
    {
        private readonly IHigherYearRequestRepository _repo;

        public UpdateHigherYearRequestService(IHigherYearRequestRepository repo)
        {
            _repo = repo;
        }

        public async Task<bool> ExecuteAsync(int requestId, UpdateHigherYearRequestDto dto)
        {
            var model = await _repo.GetByIdForUpdateAsync(requestId);
            if (model == null) return false;

            if (model.Status != HigherYearRequestStatus.Pending)
                throw new InvalidOperationException("Only Pending requests can be updated.");

            model.YearId = dto.YearId;
            model.SectionId = dto.SectionId;
            model.SemesterId = dto.SemesterId;
            model.SubjectIds = dto.SelectedSubjectIds.Distinct().ToList();

            return await _repo.UpdateAsync(model);
        }
    }

}
