using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FEEE.Infrastructure.Persistence.Models
{
    public partial class Semester
    {
        public int SemesterId { get; set; }

        public string Name { get; set; } = null!;

        public int Order { get; set; }

        public bool IsActive { get; set; }

        public int YearId { get; set; }

        public virtual Year Year { get; set; } = null!;

        public virtual ICollection<Subject> Subjects { get; set; }
            = new List<Subject>();
    }

}
