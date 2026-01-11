using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FEEE.Application.DTOs.Students
{
    public class StudentListItemResponse
    {
        public int StudentId { get; set; }

        public string UniversityNumber { get; set; } = default!;
        public string FullName { get; set; } = default!;
    }
}
