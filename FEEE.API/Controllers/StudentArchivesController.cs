using FEEE.Application.DTOs.StudentArchive;
using FEEE.Application.UseCases.StudentArchive.CreateStudentArchive;
using FEEE.Application.UseCases.StudentArchive.GetAllStudentsArchive;
using FEEE.Application.UseCases.StudentArchive.GetByOperationType;
using FEEE.Application.UseCases.StudentArchive.GetStudentArchivesByStudentId;
using Microsoft.AspNetCore.Mvc;

namespace FEEE.API.Controllers
{
    [ApiController]
    [Route("api/student-archives")]
    public class StudentArchivesController : ControllerBase
    {
        private readonly CreateStudentArchiveService _create;
        private readonly GetStudentArchivesByStudentIdService _getById;
        private readonly GetStudentArchiveByOperationTypeService _service;
        private readonly GetAllStudentsArchivesService _list;
        public StudentArchivesController(
            CreateStudentArchiveService create,
            GetStudentArchivesByStudentIdService getById,
            GetStudentArchiveByOperationTypeService service,
           GetAllStudentsArchivesService list )
        {
            _create = create;
            _getById = getById;
            _service = service;
            _list = list;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateStudentArchiveRequest request)
        {
            var id = await _create.ExecuteAsync(request);
            return Ok(id);
        }

        [HttpGet("{id}StudentID")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _getById.ExecuteAsync(id);
            return Ok(result);
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAll(int pageNumber = 1, int pageSize = 30)
        {
            var result = await _list.ExecuteAsync(pageNumber, pageSize);
            return Ok(result);
        }
        [HttpGet("by-operation")]
        public async Task<IActionResult> Get([FromQuery] int operationTypeId)
        {
            var result = await _service.ExecuteAsync(operationTypeId);
            return Ok(result);
        }

    }


}
