using System;
using System.Collections.Generic;

namespace FEEE.Infrastructure.Persistence.Models;

public partial class Year
{
    public int YearId { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<StudentPromotion> StudentPromotionFromYears { get; set; } = new List<StudentPromotion>();

    public virtual ICollection<StudentPromotion> StudentPromotionToYears { get; set; } = new List<StudentPromotion>();

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();
    public virtual ICollection<StudentSubject> StudentSubjects { get; set; }
       = new List<StudentSubject>();
    public virtual ICollection<Subject> Subjects { get; set; } = new List<Subject>();
    public virtual ICollection<Semester> Semesters { get; set; }
    = new List<Semester>();
}
