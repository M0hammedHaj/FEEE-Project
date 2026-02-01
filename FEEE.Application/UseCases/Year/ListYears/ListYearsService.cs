using FEEE.Application.DTOs.Year;
using FEEE.Application.Mappings.Year;
using FEEE.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FEEE.Application.UseCases.Year.ListYears
{
    public class ListYearsService
    {
        private readonly IYearRepository _yearRepository;

        public ListYearsService(IYearRepository yearRepository)
        {
            _yearRepository = yearRepository;
        }

        public async Task<List<YearListItemResponse>> ExecuteAsync()
        {
            var years = await _yearRepository.GetAllAsync();

            return years
                .Select(YearMapper.ToListItem)
                .ToList();
        }
    }

}
