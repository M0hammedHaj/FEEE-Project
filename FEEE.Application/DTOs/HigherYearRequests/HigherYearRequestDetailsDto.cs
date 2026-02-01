using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FEEE.Application.DTOs.HigherYearRequests
{
    public class HigherYearRequestDetailsDto
    {
        public int RequestId { get; set; }
        public DateTime RequestDate { get; set; }
        public string Status { get; set; } = null!;

        public StudentInfoDto Student { get; set; } = null!;
        public LookupDto Section { get; set; } = null!;
        public LookupDto Year { get; set; } = null!;
        public LookupDto Semester { get; set; } = null!;

        public List<SubjectDto> SelectedSubjects { get; set; } = new();
       // public List<SubjectDto> RemainingSubjects { get; set; } = new();
    }

    public class StudentInfoDto
    {
        public string FullName { get; set; } = null!;
        public string UniversityNumber { get; set; } = null!;
        public DateTime? BirthDate { get; set; }
    }

    public class LookupDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
    }

    public class SubjectDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
    }

}
