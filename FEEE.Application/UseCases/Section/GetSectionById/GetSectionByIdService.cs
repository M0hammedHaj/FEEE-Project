using FEEE.Application.DTOs.Section;
using FEEE.Application.Mappings.Section;
using FEEE.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FEEE.Application.UseCases.Section.GetSectionById
{
    public class GetSectionByIdService
    {
        private readonly ISectionRepository _sectionRepository;

        public GetSectionByIdService(ISectionRepository sectionRepository)
        {
            _sectionRepository = sectionRepository;
        }

        public async Task<SectionResponse> ExecuteAsync(int sectionId)
        {
            if (sectionId <= 0)
                throw new ArgumentException("Invalid section id");

            var section = await _sectionRepository.GetByIdAsync(sectionId);
            if (section == null)
                throw new Exception("Section not found");

            return SectionMapper.ToResponse(section);
        }
    }
}
