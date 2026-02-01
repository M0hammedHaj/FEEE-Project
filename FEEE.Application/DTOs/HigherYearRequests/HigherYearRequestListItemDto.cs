using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FEEE.Application.DTOs.HigherYearRequests
{
    public class HigherYearRequestListItemDto
    {
        public int RequestId { get; set; }
        public string StudentName { get; set; } = string.Empty;
        public string UniversityNumber { get; set; } = string.Empty;
        public string Section { get; set; } = string.Empty;
        public string Year { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public DateTime RequestDate { get; set; }
    }
}
