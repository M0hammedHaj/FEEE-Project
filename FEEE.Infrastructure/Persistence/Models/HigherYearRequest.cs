using FEEE.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FEEE.Infrastructure.Persistence.Models
{
    public partial class HigherYearRequest
    {
        public int Id { get; set; }

        public int StudentId { get; set; }
        public int YearId { get; set; }
        public int SectionId { get; set; }
        public int SemesterId { get; set; }

        public DateTime CreatedAt { get; set; }
        public HigherYearRequestStatus Status { get; set; }

        public virtual Student Student { get; set; } = null!;
        public virtual Year Year { get; set; } = null!;
        public virtual Section Section { get; set; } = null!;
        public virtual Semester Semester { get; set; } = null!;

        public virtual ICollection<HigherYearRequestSubject> HigherYearRequestSubjects { get; set; }
            = new List<HigherYearRequestSubject>();
    }
}
