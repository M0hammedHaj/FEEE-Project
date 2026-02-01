using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace FEEE.Domain.Entities
{
    public class SubjectModel
    {
        public int SubjectId { get; set; }
        public string Name { get; set; } = null!;
        public string? Code { get; set; }
        public int? YearId { get; set; }
        public int SectionId { get; set; }  // New Adeed
        public Section Section { get; set; }   // Navigation   New Adeed
        public bool? HasPractical { get; set; }
    }
}
