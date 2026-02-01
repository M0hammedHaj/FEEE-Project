using FEEE.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FEEE.Domain.Entities
{
    public class HigherYearRequestModel
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int YearId { get; set; }
        public int SectionId { get; set; }
        public int SemesterId { get; set; }
        public DateTime CreatedAt { get; set; }
        public HigherYearRequestStatus Status { get; set; }
       
        public List<int> SubjectIds { get; set; } = new();

        public List<HigherYearRequestSubjectModel> Subjects { get; set; } = [];
    }
}
