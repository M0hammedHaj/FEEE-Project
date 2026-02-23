using FEEE.Application.DTOs.OperationType;
using FEEE.Application.UseCases.OperationType.CreateOperationType;
using FEEE.Application.UseCases.OperationType.GetOperationTypeById;
using FEEE.Application.UseCases.OperationType.GetOperationTypes;
using FEEE.Application.UseCases.OperationType.UpdateOperationType;
using Microsoft.AspNetCore.Mvc;

namespace FEEE.API.Controllers
{
    [ApiController]
    [Route("api/operation-types")]
    public class OperationTypesController : ControllerBase
    {
        private readonly CreateOperationTypeService _create;
        private readonly UpdateOperationTypeService _update;
        private readonly GetOperationTypeByIdService _getById;
        private readonly ListOperationTypesService _list;

        public OperationTypesController(
            CreateOperationTypeService create,
            UpdateOperationTypeService update,
            GetOperationTypeByIdService getById,
            ListOperationTypesService list)
        {
            _create = create;
            _update = update;
            _getById = getById;
            _list = list;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateOperationTypeRequest request)
        {
            var id = await _create.ExecuteAsync(request);
            return Ok(id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateOperationTypeRequest request)
        {
            request.OperationTypeId = id;
            await _update.ExecuteAsync(request);
            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _getById.ExecuteAsync(id);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _list.ExecuteAsync();
            return Ok(result);
        }
        
    }

}
