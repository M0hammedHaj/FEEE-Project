using FEEE.Application.DTOs.Section;
using FEEE.Application.Mappings.Section;
using FEEE.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FEEE.Application.UseCases.Section.ListSections
{
    public class ListSectionsService
    {
        private readonly ISectionRepository _sectionRepository;

        public ListSectionsService(ISectionRepository sectionRepository)
        {
            _sectionRepository = sectionRepository;
        }

        public async Task<List<SectionListItemResponse>> ExecuteAsync()
        {
            var sections = await _sectionRepository.GetAllAsync();

            return sections
                .Select(SectionMapper.ToListItem)
                .ToList();
        }
    }
}
