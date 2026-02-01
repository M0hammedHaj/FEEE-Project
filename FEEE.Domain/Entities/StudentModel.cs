using FEEE.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;
namespace FEEE.Domain.Entities
{

    public class StudentModel
    {
        public int StudentId { get; set; }

        public string UniversityNumber { get; set; } = default!;
        public string MinisterialNumber { get;  set; }
        public string FirstName { get; set; } = default!;

        public string LastName { get; set; } = default!;


        public string? FatherName { get; set; }

        public string? MotherName { get; set; }

        public DateTime? BirthDate { get; set; }

        public int? CityId { get; set; }

        public int? SectionId { get; set; }   // ⭐ الحل هون

        public int? YearId { get; set; }

        public StudentStatus? Status { get; set; }

       

    }
}
