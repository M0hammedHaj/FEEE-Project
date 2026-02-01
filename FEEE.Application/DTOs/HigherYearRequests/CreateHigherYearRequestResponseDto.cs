using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FEEE.Application.DTOs.HigherYearRequests
{
    public class CreateHigherYearRequestResponseDto
    {
        public int RequestId { get; set; }
        public string Status { get; set; } = "PENDING";
        public DateTime CreatedAt { get; set; }
    }

}
