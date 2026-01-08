using System;
using System.Collections.Generic;

namespace FEEE.Infrastructure.Persistence.Entities;

public partial class StudentPromotion
{
    public int StudentPromotionId { get; set; }

    public int StudentId { get; set; }

    public int FromYearId { get; set; }

    public int ToYearId { get; set; }

    public DateTime? PromotionDate { get; set; }

    public byte? Decision { get; set; }

    public virtual Year FromYear { get; set; } = null!;

    public virtual Student Student { get; set; } = null!;

    public virtual Year ToYear { get; set; } = null!;
}
