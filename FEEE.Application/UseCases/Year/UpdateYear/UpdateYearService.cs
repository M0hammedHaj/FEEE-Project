using FEEE.Application.DTOs.Year;
using FEEE.Application.Mappings.Year;
using FEEE.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FEEE.Application.UseCases.Year.UpdateYear
{
    public class UpdateYearService
    {
        private readonly IYearRepository _yearRepository;

        public UpdateYearService(IYearRepository yearRepository)
        {
            _yearRepository = yearRepository;
        }

        public async Task ExecuteAsync(UpdateYearRequest request)
        {
            var year = await _yearRepository.GetByIdAsync(request.YearId);
            if (year == null)
                throw new Exception("Year not found");

            YearMapper.UpdateModel(year, request);
            await _yearRepository.UpdateAsync(year);
        }
    }

}
