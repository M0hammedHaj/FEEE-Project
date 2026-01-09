using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FEEE.Domain.Models
{
    public class StudentPromotionModel
    {
        public int StudentPromotionId { get; set; }

        public int StudentId { get; set; }

        public int FromYearId { get; set; }

        public int ToYearId { get; set; }

        public DateTime? PromotionDate { get; set; }

        public byte? Decision { get; set; }
    }
}
