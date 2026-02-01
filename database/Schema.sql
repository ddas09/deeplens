-- Drop tables if they exist (child tables first)
DROP TABLE IF EXISTS api_usage CASCADE;
DROP TABLE IF EXISTS daily_event_aggregates CASCADE;
DROP TABLE IF EXISTS events CASCADE;
DROP TABLE IF EXISTS api_keys CASCADE;
DROP TABLE IF EXISTS tenants CASCADE;

-- Tenants
CREATE TABLE tenants (
    id UUID PRIMARY KEY,
    name VARCHAR(255) NOT NULL,
    created_at TIMESTAMPTZ NOT NULL DEFAULT NOW(),
    updated_at TIMESTAMPTZ NOT NULL DEFAULT NOW(),
    created_by VARCHAR(100),
    updated_by VARCHAR(100)
);

-- API Keys
CREATE TABLE api_keys (
    id UUID PRIMARY KEY,
    tenant_id UUID NOT NULL,
    secret_key VARCHAR(255) NOT NULL,
    is_active BOOLEAN NOT NULL DEFAULT TRUE,
    created_at TIMESTAMPTZ NOT NULL DEFAULT NOW(),
    updated_at TIMESTAMPTZ NOT NULL DEFAULT NOW(),
    created_by VARCHAR(100),
    updated_by VARCHAR(100),

    CONSTRAINT fk_api_keys_tenant
        FOREIGN KEY (tenant_id) REFERENCES tenants(id)
);

-- Events
CREATE TABLE events (
    id UUID PRIMARY KEY,
    tenant_id UUID NOT NULL,
    event_name VARCHAR(100) NOT NULL,
    event_time TIMESTAMPTZ NOT NULL,
    metadata JSONB,

    created_at TIMESTAMPTZ NOT NULL DEFAULT NOW(),
    updated_at TIMESTAMPTZ NOT NULL DEFAULT NOW(),
    created_by VARCHAR(100),
    updated_by VARCHAR(100),

    CONSTRAINT fk_events_tenant
        FOREIGN KEY (tenant_id) REFERENCES tenants(id)
);

-- Daily Event Aggregates
CREATE TABLE daily_event_aggregates (
    id UUID PRIMARY KEY,
    tenant_id UUID NOT NULL,
    event_name VARCHAR(100) NOT NULL,
    event_date DATE NOT NULL,
    event_count BIGINT NOT NULL,

    created_at TIMESTAMPTZ NOT NULL DEFAULT NOW(),
    updated_at TIMESTAMPTZ NOT NULL DEFAULT NOW(),
    created_by VARCHAR(100),
    updated_by VARCHAR(100),

    CONSTRAINT fk_daily_agg_tenant
        FOREIGN KEY (tenant_id) REFERENCES tenants(id),

    CONSTRAINT unique_daily_event
        UNIQUE (tenant_id, event_name, event_date)
);

-- API Usage
CREATE TABLE api_usage (
    id UUID PRIMARY KEY,
    tenant_id UUID NOT NULL,
    api_key_value VARCHAR(255),
    endpoint VARCHAR(255),
    request_time TIMESTAMPTZ NOT NULL,
    status_code INT,

    created_at TIMESTAMPTZ NOT NULL DEFAULT NOW(),
    updated_at TIMESTAMPTZ NOT NULL DEFAULT NOW(),
    created_by VARCHAR(100),
    updated_by VARCHAR(100),

    CONSTRAINT fk_api_usage_tenant
        FOREIGN KEY (tenant_id) REFERENCES tenants(id)
);
