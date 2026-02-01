using FEEE.Application.DTOs.Section;
using FEEE.Application.Mappings.Section;
using FEEE.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FEEE.Application.UseCases.Section.UpdateSection
{
    public class UpdateSectionService
    {
        private readonly ISectionRepository _sectionRepository;

        public UpdateSectionService(ISectionRepository sectionRepository)
        {
            _sectionRepository = sectionRepository;
        }

        public async Task ExecuteAsync(UpdateSectionRequest request)
        {
            var section = await _sectionRepository.GetByIdAsync(request.SectionId);
            if (section == null)
                throw new Exception("Section not found");

            SectionMapper.UpdateModel(section, request);
            await _sectionRepository.UpdateAsync(section);
        }
    }
}
