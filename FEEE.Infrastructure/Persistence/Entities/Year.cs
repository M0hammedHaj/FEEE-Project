using System;
using System.Collections.Generic;

namespace FEEE.Infrastructure.Persistence.Entities;

public partial class Year
{
    public int YearId { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<StudentPromotion> StudentPromotionFromYears { get; set; } = new List<StudentPromotion>();

    public virtual ICollection<StudentPromotion> StudentPromotionToYears { get; set; } = new List<StudentPromotion>();

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();

    public virtual ICollection<Subject> Subjects { get; set; } = new List<Subject>();
}
