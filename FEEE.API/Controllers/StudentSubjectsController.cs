using FEEE.Application.DTOs.StudentSubject;
using FEEE.Application.UseCases.StudentSubject.FailStudentSubject;
using FEEE.Application.UseCases.StudentSubject.GetStudentSubjects;
using FEEE.Application.UseCases.StudentSubject.PassStudentSubject;
using Microsoft.AspNetCore.Mvc;

namespace FEEE.API.Controllers
{
    [ApiController]
    [Route("api/student-subjects")]
    public class StudentSubjectsController : ControllerBase
    {
        private readonly FailStudentSubjectService _fail;
        private readonly PassStudentSubjectService _pass;
        private readonly GetStudentSubjectsService _getByStudent;

        public StudentSubjectsController(
            FailStudentSubjectService fail,
            PassStudentSubjectService pass,
            GetStudentSubjectsService getByStudent)
        {
            _fail = fail;
            _pass = pass;
            _getByStudent = getByStudent;
        }

        // GET: api/student-subjects?studentId=5
        [HttpGet]
        public async Task<IActionResult> GetByStudent(
            [FromQuery] int studentId)
        {
            var request = new GetStudentSubjectsRequest
            {
                StudentId = studentId
            };

            var result = await _getByStudent.ExecuteAsync(request);
            return Ok(result);
        }

        // POST: api/student-subjects/{id}/pass
        [HttpPost("{id}/pass")]
        public async Task<IActionResult> Pass(int id)
        {
            await _pass.ExecuteAsync(id);
            return NoContent();
        }

        // POST: api/student-subjects/{id}/fail
        [HttpPost("{id}/fail")]
        public async Task<IActionResult> Fail(int id)
        {
            await _fail.ExecuteAsync(id);
            return NoContent();
        }
    }

}
