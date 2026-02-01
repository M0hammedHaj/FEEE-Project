using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FEEE.Application.DTOs.Semesters
{
    public class SemesterResponseDto
    {
        public int SemesterId { get; set; }
        public string Name { get; set; } = null!;
        public int Order { get; set; }
    }

}
