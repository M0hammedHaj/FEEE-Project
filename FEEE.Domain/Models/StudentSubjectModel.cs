using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FEEE.Domain.Models
{
    public class StudentSubjectModel
    {
        public int StudentSubjectId { get; set; }

        public int StudentId { get; set; }

        public int SubjectId { get; set; }

        public string? AcademicYear { get; set; }

        public byte? Semester { get; set; }

        public int? Status { get; set; }
    }
}
