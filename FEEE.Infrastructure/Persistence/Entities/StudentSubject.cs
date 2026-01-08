using System;
using System.Collections.Generic;

namespace FEEE.Infrastructure.Persistence.Entities;

public partial class StudentSubject
{
    public int StudentSubjectId { get; set; }

    public int StudentId { get; set; }

    public int SubjectId { get; set; }

    public string? AcademicYear { get; set; }

    public byte? Semester { get; set; }

    public int? Status { get; set; }

    public virtual Student Student { get; set; } = null!;

    public virtual Subject Subject { get; set; } = null!;
}
