using System;
using System.Collections.Generic;

namespace DeepLens.Data.Entities;

public partial class Tenant
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public string? CreatedBy { get; set; }

    public string? UpdatedBy { get; set; }

    public virtual ICollection<ApiKey> ApiKeys { get; set; } = new List<ApiKey>();

    public virtual ICollection<ApiUsage> ApiUsages { get; set; } = new List<ApiUsage>();

    public virtual ICollection<DailyEventAggregate> DailyEventAggregates { get; set; } = new List<DailyEventAggregate>();

    public virtual ICollection<Event> Events { get; set; } = new List<Event>();
}
