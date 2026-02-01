using FEEE.Application.DTOs.City;
using FEEE.Application.DTOs.Section;
using FEEE.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FEEE.Application.Mappings.Section
{
    public static class SectionMapper
    {
        public static SectionModel ToModel(CreateSectionRequest request) =>
            new SectionModel
            {
                Name = request.Name,
                Active = request.Active
            };

        public static void UpdateModel(SectionModel Section, UpdateSectionRequest request)
        {
            Section.Name = request.Name;
            Section.Active = request.Active;
        }

        public static SectionResponse ToResponse(SectionModel section) =>
            new SectionResponse
            {
                SectionId = section.SectionId,
                Name = section.Name,
                Active = section.Active
            };

        public static SectionListItemResponse ToListItem(SectionModel section) =>
            new SectionListItemResponse
            {
                SectionId = section.SectionId,
                Name = section.Name,
                Active = section.Active
            };



    }
}
