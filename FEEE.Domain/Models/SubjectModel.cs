using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FEEE.Domain.Models
{
    public class SubjectModel
    {
        public int SubjectId { get; set; }
        public string Name { get; set; } = null!;
        public string? Code { get; set; }
        public int? YearId { get; set; }
        public bool? HasPractical { get; set; }
    }
}
