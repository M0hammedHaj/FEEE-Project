using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FEEE.Application.DTOs.OperationType;
using FEEE.Application.Mappings.OperationTypes;
using FEEE.Domain.Interfaces;

namespace FEEE.Application.UseCases.OperationType.UpdateOperationType
{
   

    public class UpdateOperationTypeService
    {
        private readonly IOperationTypeRepository _repository;

        public UpdateOperationTypeService(IOperationTypeRepository repository)
        {
            _repository = repository;
        }

        public async Task ExecuteAsync(UpdateOperationTypeRequest request)
        {
            var operationType = await _repository.GetByIdAsync(request.OperationTypeId);
            if (operationType == null)
                throw new Exception("Operation type not found");

            OperationTypeMapper.UpdateModel(operationType, request);
            await _repository.UpdateAsync(operationType);
        }
    }

}
