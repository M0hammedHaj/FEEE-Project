using FEEE.Domain.Enums;
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
        public string FatherName { get; set; } = default!;
        public string MotherName { get; set; } = default!;
        public string  MinisterialNumber { get; set; }
        public DateTime? BirthDate { get; set; }

        public int? CityId { get; set; }
        public int? SectionId { get; set; }
        public int? YearId { get; set; }

        public StudentStatus Status { get; set; }

    }
}
