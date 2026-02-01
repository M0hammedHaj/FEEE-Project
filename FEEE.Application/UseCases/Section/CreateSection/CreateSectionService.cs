using FEEE.Application.DTOs.Section;
using FEEE.Application.DTOs.Students;
using FEEE.Application.Mappings.Section;
using FEEE.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FEEE.Application.UseCases.Section.CreateSection
{
    public class CreateSectionService
    {
        private readonly ISectionRepository _sectionRepository;
        public CreateSectionService(ISectionRepository sectionRepository)
            =>
            _sectionRepository = sectionRepository;

        public async Task<int> ExecuteAsync(CreateSectionRequest request)
        {
            var section = SectionMapper.ToModel(request);

            var id =await _sectionRepository.AddAsync(section);
            return id;
        }
    }
}
