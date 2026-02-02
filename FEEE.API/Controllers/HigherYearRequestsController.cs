using FEEE.Application.DTOs.HigherYearRequests;
using FEEE.Application.UseCases.HigherYearRequests.CancelHigherYearRequestService;
using FEEE.Application.UseCases.HigherYearRequests.CreateHigherYearRequestServices;
using FEEE.Application.UseCases.HigherYearRequests.GetFilterHigherYearRequestListService;
using FEEE.Application.UseCases.HigherYearRequests.GetHigherYearRequestByIdUseCase;
using FEEE.Application.UseCases.HigherYearRequests.GetHigherYearRequestsService;
using FEEE.Application.UseCases.HigherYearRequests.UpdateHigherYearRequestService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FEEE.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HigherYearRequestsController : ControllerBase
    {
        private readonly CreateHigherYearRequestService _service;
        private readonly GetAllHigherYearRequestsService _getAllService;
        private readonly GetHigherYearRequestByIdUseCase _getById;
        private readonly UpdateHigherYearRequestService _updateService;
        private readonly CancelHigherYearRequestService _deleteService;
        private readonly GetFilterHigherYearRequestListService _filterService;

        public HigherYearRequestsController(CreateHigherYearRequestService service,GetAllHigherYearRequestsService getallservice,
            GetHigherYearRequestByIdUseCase getbyid, UpdateHigherYearRequestService updateservice,
            CancelHigherYearRequestService cancelHigherYearRequestService,
            GetFilterHigherYearRequestListService getFilterHigherYearRequestListService)
        {
            _service = service;
            _getAllService = getallservice;
            _getById = getbyid;
            _updateService = updateservice;
            _deleteService = cancelHigherYearRequestService;
            _filterService = getFilterHigherYearRequestListService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateHigherYearRequestDto dto)
        {
            var result = await _service.HandleAsync(dto);
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var list = await _getAllService.HandleAsync();
            return Ok(list);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _getById.HandleAsync(id);
            if (result == null) return NotFound();
            return Ok(result);
        }
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateHigherYearRequestDto dto)
        {
            var ok = await _updateService.ExecuteAsync(id, dto);
            if (!ok) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var ok = await _deleteService.ExecuteAsync(id);
            if (!ok) return NotFound();
            return NoContent();
        }
        [HttpGet("Filter")]
        public async Task<IActionResult> GetList([FromQuery] HigherYearRequestFilterDto filter)
        {
            var result = await _filterService.ExecuteAsync(filter);
            return Ok(result);
        }


    }
}
