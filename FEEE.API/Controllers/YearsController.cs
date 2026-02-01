using FEEE.Application.DTOs.Year;
using FEEE.Application.UseCases.Year.CreateYear;
using FEEE.Application.UseCases.Year.GetSemestersByYear;
using FEEE.Application.UseCases.Year.GetYearById;
using FEEE.Application.UseCases.Year.ListYears;
using FEEE.Application.UseCases.Year.UpdateYear;
using Microsoft.AspNetCore.Mvc;



namespace FEEE.API.Controllers
{
    [ApiController]
    [Route("api/years")]
    public class YearsController : ControllerBase
    {
        private readonly CreateYearService _create;
        private readonly UpdateYearService _update;
        private readonly GetYearByIdService _getById;
        private readonly ListYearsService _list;
        private readonly MediatR.IMediator _mediator;
        public YearsController(
            CreateYearService create,
            UpdateYearService update,
            GetYearByIdService getById,
            ListYearsService list,
            MediatR.IMediator mediator)
        {
            _create = create;
            _update = update;
            _getById = getById;
            _list = list;
            _mediator = mediator;

        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateYearRequest request)
        {
            var id = await _create.ExecuteAsync(request);
            return Ok(id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateYearRequest request)
        {
            request.YearId = id;
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
        [HttpGet("{yearId}/semesters")]
        public async Task<IActionResult> GetSemestersByYear(int yearId)
        {
            var result = await _mediator.Send(
                new GetSemestersByYearQuery(yearId));

            return Ok(result);
        }
    }

}
