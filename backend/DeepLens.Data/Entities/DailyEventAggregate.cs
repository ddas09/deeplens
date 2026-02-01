using System;
using System.Collections.Generic;

namespace DeepLens.Data.Entities;

public partial class DailyEventAggregate
{
    public Guid Id { get; set; }

    public Guid TenantId { get; set; }

    public string EventName { get; set; } = null!;

    public DateOnly EventDate { get; set; }

    public long EventCount { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public string? CreatedBy { get; set; }

    public string? UpdatedBy { get; set; }

    public virtual Tenant Tenant { get; set; } = null!;
}
