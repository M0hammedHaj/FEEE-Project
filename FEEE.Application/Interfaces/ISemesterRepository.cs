using FEEE.Application.DTOs.Semesters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FEEE.Application.Interfaces
{
    public interface ISemesterRepository
    {
        Task<List<SemesterResponseDto>> GetByYearIdAsync(int yearId);
    }

}
