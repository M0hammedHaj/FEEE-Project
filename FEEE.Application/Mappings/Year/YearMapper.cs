using FEEE.Application.DTOs.Year;
using FEEE.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FEEE.Application.Mappings.Year
{
    public static class YearMapper
    {
        public static YearModel ToModel(CreateYearRequest request) =>
            new YearModel
            {
                Name = request.Name
            };

        public static void UpdateModel(YearModel year, UpdateYearRequest request)
        {
            year.Name = request.Name;
        }

        public static YearResponse ToResponse(YearModel year) =>
            new YearResponse
            {
                YearId = year.YearId,
                Name = year.Name
            };

        public static YearListItemResponse ToListItem(YearModel year) =>
            new YearListItemResponse
            {
                YearId = year.YearId,
                Name = year.Name
            };
    }
}
