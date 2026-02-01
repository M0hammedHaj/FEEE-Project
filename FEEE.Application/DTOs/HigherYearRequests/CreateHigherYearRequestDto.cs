using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FEEE.Application.DTOs.HigherYearRequests
{
    public class CreateHigherYearRequestDto
    {
        public int StudentId { get; set; }
        public int YearId { get; set; }
        public int SectionId { get; set; }
        public int SemesterId { get; set; }
        public List<int> SelectedSubjectIds { get; set; } = new();
    }
}
