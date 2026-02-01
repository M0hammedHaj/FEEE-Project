using FEEE.Application.DTOs.City;
using FEEE.Application.Mappings.Cities;
using FEEE.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FEEE.Application.UseCases.City.GetCityById
{
    public class GetCityByIdService
    {
        private readonly ICityRepository _cityRepository;

        public GetCityByIdService(ICityRepository cityRepository)
        {
            _cityRepository = cityRepository;
        }

        public async Task<CityResponse> ExecuteAsync(int cityId)
        {
            var city = await _cityRepository.GetByIdAsync(cityId);
            if (city == null)
                throw new Exception("City not found");

            return CityMapper.ToResponse(city);
        }
    }

}
