using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FEEE.Domain.Models
{
    public class StudentArchiveModel
    {
        public int StudentArchiveId { get; set; }

        public int ArchiveNumber { get; set; }

        public int StudentId { get; set; }

        public int OperationType { get; set; }

        public DateTime? ArchiveDate { get; set; }

        public string? Notes { get; set; }

        public int UserId { get; set; }
    }
}
