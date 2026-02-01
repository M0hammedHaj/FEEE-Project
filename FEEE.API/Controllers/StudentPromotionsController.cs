using FEEE.Application.DTOs.StudentPromotion;
using FEEE.Application.UseCases.StudentPromotion.CreateStudentPromotion;
using FEEE.Application.UseCases.StudentPromotion.GetStudentPromotionsByStudentId;
using Microsoft.AspNetCore.Mvc;

namespace FEEE.API.Controllers
{
    [ApiController]
    [Route("api/student-promotions")]
    public class StudentPromotionsController : ControllerBase
    {
        private readonly CreateStudentPromotionService _create;
        private readonly GetStudentPromotionsByStudentIdService _getById;
       

        public StudentPromotionsController(
            CreateStudentPromotionService create,
            GetStudentPromotionsByStudentIdService getById
          )
        {
            _create = create;
            _getById = getById;
           
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateStudentPromotionRequest request)
        {
            var id = await _create.ExecuteAsync(request);
            return Ok(id);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _getById.ExecuteAsync(id);
            return Ok(result);
        }

        //[HttpGet]
        //public async Task<IActionResult> GetAll()
        //{
        //    var result = await _list.ExecuteAsync();
        //    return Ok(result);
        //}


    }
}
