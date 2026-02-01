using FEEE.Application.DTOs.City;
using FEEE.Application.Mappings.Cities;
using FEEE.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FEEE.Application.UseCases.City.ListCities
{
    public class ListCitiesService
    {
        private readonly ICityRepository _cityRepository;

        public ListCitiesService(ICityRepository cityRepository)
        {
            _cityRepository = cityRepository;
        }

        public async Task<List<CityListItemResponse>> ExecuteAsync()
        {
            var cities = await _cityRepository.GetAllAsync();
            return cities.Select(CityMapper.ToListItem).ToList();
        }
    }

}
