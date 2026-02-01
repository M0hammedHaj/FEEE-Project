using FEEE.Application.DTOs.HigherYearRequests;
using FEEE.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FEEE.Application.UseCases.HigherYearRequests.GetHigherYearRequestByIdUseCase
{
    public class GetHigherYearRequestByIdUseCase
    {
        private readonly IHigherYearRequestRepository _repo;

        public GetHigherYearRequestByIdUseCase(IHigherYearRequestRepository repo)
        {
            _repo = repo;
        }

        public Task<HigherYearRequestDetailsDto?> HandleAsync(int id)
            => _repo.GetByIdAsync(id);
    }

}
