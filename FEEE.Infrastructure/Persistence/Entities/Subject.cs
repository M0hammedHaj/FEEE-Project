using System;
using System.Collections.Generic;

namespace FEEE.Infrastructure.Persistence.Entities;

public partial class Subject
{
    public int SubjectId { get; set; }

    public string Name { get; set; } = null!;

    public string? Code { get; set; }

    public int? YearId { get; set; }

    public bool? HasPractical { get; set; }

    public virtual ICollection<StudentSubject> StudentSubjects { get; set; } = new List<StudentSubject>();

    public virtual Year? Year { get; set; }

    public virtual ICollection<Section> Sections { get; set; } = new List<Section>();
}
