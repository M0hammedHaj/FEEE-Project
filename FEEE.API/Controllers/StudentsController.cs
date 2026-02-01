using FEEE.Application.DTOs.Students;
using FEEE.Application.UseCases.Student.CreateStudent;
using FEEE.Application.UseCases.Student.GetStudentById;
using FEEE.Application.UseCases.Student.ListStudents;
using FEEE.Application.UseCases.Student.SearchStudents;
using FEEE.Application.UseCases.Student.UpdateStudent;
using Microsoft.AspNetCore.Mvc;

namespace FEEE.API.Controllers
{
    [ApiController]
    [Route("api/students")]
    public class StudentsController : ControllerBase
    {

        private readonly CreateStudentService _createStudent;
        private readonly UpdateStudentService _updateStudent;
        private readonly GetStudentByIdService _getById;
        private readonly ListStudentsService _list;
        private readonly MediatR.IMediator _mediator;

        public StudentsController(
            CreateStudentService createStudent,
            UpdateStudentService updateStudent,
            GetStudentByIdService getById,
            ListStudentsService list,
            MediatR.IMediator mediator)
        {
            _createStudent = createStudent;
            _updateStudent = updateStudent;
            _getById = getById;
            _list = list;
            _mediator = mediator;

        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateStudentRequest request)
        {
            var id = await _createStudent.ExecuteAsync(request);
            return Ok(id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateStudentRequest request)
        {
            request.StudentId = id;
            await _updateStudent.ExecuteAsync(request);
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
        [HttpGet("search")]
        public async Task<IActionResult> Search(
    [FromQuery] string? universityNumber,
    [FromQuery] string? fullName)
        {
            var result = await _mediator.Send(
                new SearchStudentsQuery
                {
                    UniversityNumber = universityNumber,
                    FullName = fullName
                });

            return Ok(result);
        }




        

    }


}
