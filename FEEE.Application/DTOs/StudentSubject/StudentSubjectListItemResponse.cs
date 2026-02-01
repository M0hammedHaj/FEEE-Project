using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FEEE.Application.DTOs.StudentSubject
{
    public class StudentSubjectListItemResponse
    {
        public int StudentSubjectId { get; set; }
        public int SubjectId { get; set; }
        public int YearId { get; set; }
        public byte Semester { get; set; }
        public string Status { get; set; } = null!;
    }

}
