using FEEE.Application.DTOs.City;
using FEEE.Application.UseCases.City.CreateCity;
using FEEE.Application.UseCases.City.GetCityById;
using FEEE.Application.UseCases.City.ListCities;
using FEEE.Application.UseCases.City.UpdateCity;
using Microsoft.AspNetCore.Mvc;

namespace FEEE.API.Controllers
{

    [ApiController]
    [Route("api/cities")]

    public class CitiesController : ControllerBase
    {
        private readonly CreateCityService _createCity;
        private readonly UpdateCityService _updateCity;
        private readonly GetCityByIdService _getById;
        private readonly ListCitiesService _list;

        public CitiesController(
            CreateCityService createCity,
            UpdateCityService updateCity,
            GetCityByIdService getById,
            ListCitiesService list)
        {
            _createCity = createCity;
            _updateCity = updateCity;
            _getById = getById;
            _list = list;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCityRequest request)
        {
            var id = await _createCity.ExecuteAsync(request);
            return Ok(id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateCityRequest request)
        {
            request.CityId = id;
            await _updateCity.ExecuteAsync(request);
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
