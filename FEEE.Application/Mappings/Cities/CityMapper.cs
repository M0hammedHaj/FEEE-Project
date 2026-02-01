using FEEE.Application.DTOs.City;
using FEEE.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FEEE.Application.Mappings.Cities
{
    public static class CityMapper
    {
        public static CityModel ToModel(CreateCityRequest request)
        {
            return new CityModel
            {
                Name = request.Name
            };
        }

        public static void UpdateModel(CityModel city, UpdateCityRequest request)
        {
            city.Name = request.Name;
        }

        public static CityResponse ToResponse(CityModel city)
        {
            return new CityResponse
            {
                CityId = city.CityId,
                Name = city.Name
            };
        }

        public static CityListItemResponse ToListItem(CityModel city)
        {
            return new CityListItemResponse
            {
                CityId = city.CityId,
                Name = city.Name
            };
        }
    }
}
