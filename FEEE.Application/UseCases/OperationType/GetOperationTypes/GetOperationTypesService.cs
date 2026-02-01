using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FEEE.Application.DTOs.OperationType;
using FEEE.Application.Mappings.OperationTypes;
using FEEE.Domain.Interfaces;

namespace FEEE.Application.UseCases.OperationType.GetOperationTypes
{
   

    public class ListOperationTypesService
    {
        private readonly IOperationTypeRepository _repository;

        public ListOperationTypesService(IOperationTypeRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<OperationTypeResponse>> ExecuteAsync()
        {
            var items = await _repository.GetAllAsync();
            return items.Select(OperationTypeMapper.ToResponse).ToList();
        }
    }

}
