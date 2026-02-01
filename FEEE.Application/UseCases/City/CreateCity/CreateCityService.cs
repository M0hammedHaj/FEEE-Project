using FEEE.Application.DTOs.City;
using FEEE.Application.Mappings.Cities;
using FEEE.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FEEE.Application.UseCases.City.CreateCity
{
    public class CreateCityService
    {
        private readonly ICityRepository _cityRepository;

        public CreateCityService(ICityRepository cityRepository)
        {
            _cityRepository = cityRepository;
        }

        public async Task<int> ExecuteAsync(CreateCityRequest request)
        {
            var city = CityMapper.ToModel(request);
            var id = await _cityRepository.AddAsync(city);
            return id;
        }
    }
}
