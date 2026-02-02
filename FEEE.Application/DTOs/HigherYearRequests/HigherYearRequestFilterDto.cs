using FEEE.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FEEE.Application.DTOs.HigherYearRequests
{
    public class HigherYearRequestFilterDto
    {
        public int? SectionId { get; set; }
        public int? YearId { get; set; }
        public HigherYearRequestStatus? Status { get; set; }
        public string? StudentName { get; set; }
        public string? UniversityNumber { get; set; }
        public DateTime? Date { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
    }

}
