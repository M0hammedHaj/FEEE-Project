using System;
using System.Collections.Generic;

namespace FEEE.Infrastructure.Persistence.Entities;

public partial class Section
{
    public int SectionId { get; set; }

    public string Name { get; set; } = null!;

    public bool Active { get; set; }

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();

    public virtual ICollection<Subject> Subjects { get; set; } = new List<Subject>();
}
