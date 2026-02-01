using FEEE.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FEEE.Domain.Entities
{
    public class StudentSubjectModel
    {
        public int StudentSubjectId { get; set; }

        public int StudentId { get; set; }
        public int SubjectId { get; set; }
        public int YearId { get; set; }

        public byte Semester { get; set; }

        public StudentSubjectStatus Status { get; set; }
    }
}
