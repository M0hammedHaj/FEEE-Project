using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FEEE.Application.DTOs.Subject
{
    public class SubjectResponseDto
    {
        public int SubjectId { get; set; }
        public string Name { get; set; } = null!;
        public string? Code { get; set; }
        public bool? HasPractical { get; set; }
    }
}
