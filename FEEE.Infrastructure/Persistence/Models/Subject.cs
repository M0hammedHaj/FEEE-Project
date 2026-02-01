using System;
using System.Collections.Generic;

namespace FEEE.Infrastructure.Persistence.Models;

public partial class Subject
{
    public int SubjectId { get; set; }
    public string Name { get; set; } = null!;
    public string? Code { get; set; }

    public int? YearId { get; set; }
    public int SemesterId { get; set; }
    public bool? HasPractical { get; set; }

    // FK to Section
    public int SectionId { get; set; }
    public Section Section { get; set; } = null!;

    // Existing relations
    public virtual Semester Semester { get; set; } = null!;
    public virtual Year? Year { get; set; }

    public virtual ICollection<StudentSubject> StudentSubjects { get; set; } = new List<StudentSubject>();

}
