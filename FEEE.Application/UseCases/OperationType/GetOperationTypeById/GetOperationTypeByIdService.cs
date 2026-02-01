using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FEEE.Application.DTOs.OperationType;
using FEEE.Application.Mappings.OperationTypes;
using FEEE.Domain.Interfaces;

namespace FEEE.Application.UseCases.OperationType.GetOperationTypeById
{
   

    public class GetOperationTypeByIdService
    {
        private readonly IOperationTypeRepository _repository;

        public GetOperationTypeByIdService(IOperationTypeRepository repository)
        {
            _repository = repository;
        }

        public async Task<OperationTypeResponse?> ExecuteAsync(int id)
        {
            var item = await _repository.GetByIdAsync(id);
            return item == null ? null : OperationTypeMapper.ToResponse(item);
        }
    }

}
