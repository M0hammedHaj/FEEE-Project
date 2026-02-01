using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FEEE.Infrastructure.Persistence.Models
{
    public partial class HigherYearRequestSubject
    {
        public int Id { get; set; }

        public int RequestId { get; set; }
        public int SubjectId { get; set; }

        public virtual HigherYearRequest Request { get; set; } = null!;
        public virtual Subject Subject { get; set; } = null!;
    }
}
