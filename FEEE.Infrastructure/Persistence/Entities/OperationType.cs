using System;
using System.Collections.Generic;

namespace FEEE.Infrastructure.Persistence.Entities;

public partial class OperationType
{
    public int OperationTypeId { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<StudentArchive> StudentArchives { get; set; } = new List<StudentArchive>();
}
