using FEEE.Application.DTOs.Year;
using FEEE.Application.Mappings.Year;
using FEEE.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FEEE.Application.UseCases.Year.CreateYear
{
    public class CreateYearService
    {
        private readonly IYearRepository _yearRepository;

        public CreateYearService(IYearRepository yearRepository)
        {
            _yearRepository = yearRepository;
        }

        public async Task<int> ExecuteAsync(CreateYearRequest request)
        {
            var year = YearMapper.ToModel(request);
            var id = await _yearRepository.AddAsync(year);
            return id;
        }
    }
}
