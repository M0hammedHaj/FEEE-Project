using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FEEE.Application.DTOs.StudentArchive
{
    public class StudentArchivePrintDto
    {
        public int ArchiveNumber { get; set; }

        public string UniversityNumber { get; set; } = null!;
        public string MinisterialNumber { get; set; } = null!;

        public string OperationTypeName { get; set; } = null!;

        public DateTime ArchiveDate { get; set; }

        public string? Notes { get; set; }
    }
}
