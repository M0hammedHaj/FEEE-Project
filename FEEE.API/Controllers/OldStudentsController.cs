using FEEE.Application.UseCases.OldStudent.GetAllOldStudent;
using FEEE.Application.UseCases.OldStudent.GetByIdOldStudent;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FEEE.API.Controllers
{
    [ApiController]
    [Route("api/old-students")]
    public class OldStudentsController : ControllerBase
    {
        private readonly ListOldStudentsService _list;
        private readonly GetOldStudentByIdService _getById;

        public OldStudentsController(
            ListOldStudentsService list,
            GetOldStudentByIdService getById)
        {
            _list = list;
            _getById = getById;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _list.ExecuteAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _getById.ExecuteAsync(id);
            if (result == null) return NotFound();
            return Ok(result);
        }
    }

}
