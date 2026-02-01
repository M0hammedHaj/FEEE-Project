using FEEE.Application.UseCases.Section.CreateSection;
using FEEE.Application.UseCases.Section.GetSectionById;
using FEEE.Application.UseCases.Section.ListSections;
using FEEE.Application.UseCases.Section.UpdateSection;
using Microsoft.AspNetCore.Mvc;
using FEEE.Application.DTOs.Section;


namespace FEEE.API.Controllers
{
    [ApiController]
    [Route("api/sections")]
    public class SectionsController : ControllerBase
    {
        private readonly CreateSectionService _create;
        private readonly UpdateSectionService _update;
        private readonly GetSectionByIdService _getById;
        private readonly ListSectionsService _list;

        public SectionsController(
            CreateSectionService create,
            UpdateSectionService update,
            GetSectionByIdService getById,
            ListSectionsService list)
        {
            _create = create;
            _update = update;
            _getById = getById;
            _list = list;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateSectionRequest request)
        {
            var id = await _create.ExecuteAsync(request);
            return Ok(id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateSectionRequest request)
        {
            request.SectionId = id;
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
