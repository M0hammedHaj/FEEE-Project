using FEEE.Application.DTOs.Year;
using FEEE.Application.Mappings.Year;
using FEEE.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FEEE.Application.UseCases.Year.GetYearById
{
    public class GetYearByIdService
    {
        private readonly IYearRepository _yearRepository;

        public GetYearByIdService(IYearRepository yearRepository)
        {
            _yearRepository = yearRepository;
        }

        public async Task<YearResponse> ExecuteAsync(int yearId)
        {
            if (yearId <= 0)
                throw new ArgumentException("Invalid year id");

            var year = await _yearRepository.GetByIdAsync(yearId);
            if (year == null)
                throw new Exception("Year not found");

            return YearMapper.ToResponse(year);
        }
    }

}
