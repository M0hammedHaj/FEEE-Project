using FEEE.Application.DTOs.HigherYearRequests;
using FEEE.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FEEE.Application.Interfaces
{
    public interface IHigherYearRequestRepository
    {
        Task<int> CreateAsync(HigherYearRequestModel request);
        Task<bool> HasPendingRequestAsync(int studentId);
        Task<List<HigherYearRequestListItemDto>> GetAllAsync();
        Task<HigherYearRequestDetailsDto?> GetByIdAsync(int requestId);
        Task<bool> UpdateAsync(HigherYearRequestModel model);
        Task<bool> CancelAsync(int requestId);
        Task<HigherYearRequestModel?> GetByIdForUpdateAsync(int id);

    }
}
