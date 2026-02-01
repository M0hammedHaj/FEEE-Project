using FEEE.Application.Interfaces;
using FEEE.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FEEE.Application.UseCases.HigherYearRequests.CancelHigherYearRequestService
{
    public class CancelHigherYearRequestService
    {
        private readonly IHigherYearRequestRepository _repo;

        public CancelHigherYearRequestService(IHigherYearRequestRepository repo)
        {
            _repo = repo;
        }

        public async Task<bool> ExecuteAsync(int requestId)
        {
            var model = await _repo.GetByIdForUpdateAsync(requestId);
            if (model == null) return false;

            if (model.Status != HigherYearRequestStatus.Pending)
                throw new InvalidOperationException("Only Pending requests can be deleted.");

            return await _repo.CancelAsync(requestId);
        }
    }

}
