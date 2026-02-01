using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FEEE.Application.DTOs.Students
{
    public class StudentSearchResponseDto
    {
        public int StudentId { get; set; }
        public string UniversityNumber { get; set; } = null!;
        public string FullName { get; set; } = null!;
        public string  MinisterialNumber { get; set; }
        public int Status { get; set; }
    }

}
