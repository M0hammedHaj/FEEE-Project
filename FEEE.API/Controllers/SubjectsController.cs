using FEEE.Application.DTOs.Subject;
using FEEE.Application.UseCases.Subject.CreateSubject;
using FEEE.Application.UseCases.Subject.GetSubjectbyId;
using FEEE.Application.UseCases.Subject.GetSubjects;
using FEEE.Application.UseCases.Subject.GetSubjectsByYS;
using FEEE.Application.UseCases.Subject.UpdateSubject;
using Microsoft.AspNetCore.Mvc;

namespace FEEE.API.Controllers
{
    [ApiController]
    [Route("api/subjects")]
    public class SubjectsController : ControllerBase
    {
        private readonly CreateSubjectService _create;
        private readonly UpdateSubjectService _update;
        private readonly GetSubjectByIdService _getById;
        private readonly GetAllSubjectsService _list;
        private readonly MediatR.IMediator _mediator;
        public SubjectsController(
            CreateSubjectService create,
            UpdateSubjectService update,
            GetSubjectByIdService getById,
            GetAllSubjectsService list,
            MediatR.IMediator mediator)
        {
            _create = create;
            _update = update;
            _getById = getById;
            _list = list;
            _mediator = mediator;

        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateSubjectRequest request)
        {
            var id = await _create.ExecuteAsync(request);
            return Ok(id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateSubjectRequest request)
        {
            request.SubjectId = id;
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
        [HttpGet("{yearId,SectionId,SemesterId}/subjects")]
        public async Task<IActionResult> GetSubjects(
    [FromQuery] int sectionId,
    [FromQuery] int yearId,
    [FromQuery] int semesterId)
        {
            var result = await _mediator.Send(new GetSubjectsQuery
            {
                SectionId = sectionId,
                YearId = yearId,
                SemesterId = semesterId
            });

            return Ok(result);
        }

    }


}
