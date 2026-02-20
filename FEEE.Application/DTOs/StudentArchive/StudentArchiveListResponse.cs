using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FEEE.Application.DTOs.StudentArchive
{
    public class StudentArchiveListResponse
    {
        public int ArchiveId { get; set; }

        public string StudentName { get; set; } = null!;
        public string UniversityNumber { get; set; } = null!;
        public string MinisterialNumber { get; set; } = null!; 

        public string OperationType { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public int totalCount { get; set; }
        public int totalPages { get; set; }
    }

}
