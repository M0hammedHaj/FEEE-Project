using System;
using System.Collections.Generic;

namespace FEEE.Infrastructure.Persistence.Models;

public partial class StudentSubject
{
    public int StudentSubjectId { get; set; }

    public int StudentId { get; set; }
    public int SubjectId { get; set; }
    public int YearId { get; set; }

    public byte Semester { get; set; }
    public byte Status { get; set; }

    public virtual Student Student { get; set; } = null!;
    public virtual Subject Subject { get; set; } = null!;
    public virtual Year Year { get; set; } = null!;
}

