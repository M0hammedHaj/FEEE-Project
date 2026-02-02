using FEEE.Application.DTOs.HigherYearRequests;
using FEEE.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FEEE.Application.UseCases.HigherYearRequests.GetFilterHigherYearRequestListService
{
    public class GetFilterHigherYearRequestListService
    {
        private readonly IHigherYearRequestRepository _repo;

        public GetFilterHigherYearRequestListService(IHigherYearRequestRepository repo)
        {
            _repo = repo;
        }

        public async Task<List<HigherYearRequestListItemDto>> ExecuteAsync(
            HigherYearRequestFilterDto filter)
        {
            return await _repo.GetListAsync(filter);
        }
    }

}
