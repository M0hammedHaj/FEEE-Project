using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FEEE.Application.DTOs.Subject
{
    public class CreateSubjectRequest
    {
        public string Name { get; set; } = null!;
        public string? Code { get; set; }
        public int? YearId { get; set; }
        public bool? HasPractical { get; set; }
    }

}
