using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FEEE.Application.DTOs.OldStudents
{
    public class OldStudentDto
    {
        public int Id { get; set; }
        public string UniversityNumber { get; set; }
        public string FullName { get; set; }
        public DateTime? BirthDate { get; set; }
        public bool IsExist { get; set; }
    }

}
