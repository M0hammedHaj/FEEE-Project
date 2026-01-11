using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FEEE.Application.DTOs.Students
{
    public class CreateStudentRequest
    {
        public string UniversityNumber { get; set; } = default!;
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;

        public string? FatherName { get; set; }
        public string? MotherName { get; set; }

        public DateTime? BirthDate { get; set; }

        public int? CityId { get; set; }
        public int? SectionId { get; set; }
        public int? YearId { get; set; }
    }
}
