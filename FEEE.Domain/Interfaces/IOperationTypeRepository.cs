using FEEE.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FEEE.Domain.Interfaces
{

    public interface IOperationTypeRepository
    {
        Task<List<OperationTypeModel>> GetAllAsync();
        Task<OperationTypeModel?> GetByIdAsync(int id);
    }
}
