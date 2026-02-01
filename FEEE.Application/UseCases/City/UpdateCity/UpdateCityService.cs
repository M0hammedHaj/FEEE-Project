using FEEE.Application.DTOs.City;
using FEEE.Application.Mappings.Cities;
using FEEE.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FEEE.Application.UseCases.City.UpdateCity
{
    public class UpdateCityService
    {
        private readonly ICityRepository _cityRepository;

        public UpdateCityService(ICityRepository cityRepository)
        {
            _cityRepository = cityRepository;
        }

        public async Task ExecuteAsync(UpdateCityRequest request)
        {
            var city = await _cityRepository.GetByIdAsync(request.CityId);
            if (city == null)
                throw new Exception("City not found");

            CityMapper.UpdateModel(city, request);
            await _cityRepository.UpdateAsync(city);
        }
    }
}
