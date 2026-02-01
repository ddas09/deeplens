using System;
using System.Collections.Generic;

namespace DeepLens.Data.Entities;

public partial class ApiUsage
{
    public Guid Id { get; set; }

    public Guid TenantId { get; set; }

    public string? ApiKeyValue { get; set; }

    public string? Endpoint { get; set; }

    public DateTime RequestTime { get; set; }

    public int? StatusCode { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public string? CreatedBy { get; set; }

    public string? UpdatedBy { get; set; }

    public virtual Tenant Tenant { get; set; } = null!;
}
