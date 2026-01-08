using System;
using System.Collections.Generic;

namespace FEEE.Infrastructure.Persistence.Entities;

public partial class StudentArchive
{
    public int StudentArchiveId { get; set; }

    public int ArchiveNumber { get; set; }

    public int StudentId { get; set; }

    public int OperationType { get; set; }

    public DateTime? ArchiveDate { get; set; }

    public string? Notes { get; set; }

    public int UserId { get; set; }

    public virtual OperationType OperationTypeNavigation { get; set; } = null!;

    public virtual Student Student { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
