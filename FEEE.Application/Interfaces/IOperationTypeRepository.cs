using FEEE.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FEEE.Domain.Interfaces
{
    public interface IOperationTypeRepository
    {
        Task<List<OperationTypeModel>> GetAllAsync();
        Task<OperationTypeModel?> GetByIdAsync(int id);

        Task <int>AddAsync(OperationTypeModel model);
        Task UpdateAsync(OperationTypeModel model);
        Task DeleteAsync(int id);
    }
}
