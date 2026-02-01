using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FEEE.Application.DTOs.StudentArchive
{
    public class CreateStudentArchiveRequest
    {
        public int ArchiveNumber { get; set; }
        public int StudentId { get; set; }
        public int OperationType { get; set; }
        public DateTime ArchiveDate { get; set; }
        public string? Notes { get; set; }
        public int UserId { get; set; }
    }

}
