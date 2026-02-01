using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FEEE.Application.DTOs.OperationType;
using FEEE.Application.Mappings.OperationTypes;
using FEEE.Domain.Interfaces;

namespace FEEE.Application.UseCases.OperationType.CreateOperationType
{
    public class CreateOperationTypeService
    {
        private readonly IOperationTypeRepository _OperationTyperepository;

        public CreateOperationTypeService(IOperationTypeRepository repository)
        {
            _OperationTyperepository = repository;
        }

        public async Task<int> ExecuteAsync(CreateOperationTypeRequest request)
        {
            var model = OperationTypeMapper.ToModel(request);
          var id =   await _OperationTyperepository.AddAsync(model);
            return id;
        }
    }
}
