using FEEE.Application.DTOs.HigherYearRequests;
using FEEE.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FEEE.Application.UseCases.HigherYearRequests.GetHigherYearRequestsService
{
    public class GetHigherYearRequestsService
    {
        private readonly IHigherYearRequestRepository _repo;

        public GetHigherYearRequestsService(IHigherYearRequestRepository repo)
        {
            _repo = repo;
        }

        public Task<List<HigherYearRequestListItemDto>> HandleAsync()
            => _repo.GetAllAsync();
    }
}
