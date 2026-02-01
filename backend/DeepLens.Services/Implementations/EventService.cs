using DeepLens.Common.Models.Request;
using DeepLens.Common.Models.Response;
using DeepLens.DAL.Interfaces;
using DeepLens.Data.Entities;
using DeepLens.Services.Interfaces;

namespace DeepLens.Services.Implementations;

public class EventService : IEventService
{
    // TODO - V1: hardcoded tenant, should come from FE or request context
    private static readonly Guid TenantId =
        Guid.Parse("6f3a9d8c-1c2e-4f7a-9c6e-8b4a0d9e2f11");
    
    private readonly IEventRepository _eventRepository;
    
    public EventService(IEventRepository eventRepository)
    {
        _eventRepository = eventRepository;
    }
    
    public async Task<EventResponse> IngestEvent(EventIngestRequest request)
    {
        if (string.IsNullOrWhiteSpace(request.EventName))
            throw new ArgumentException("EventName is required");

        if (request.EventTime == default)
            throw new ArgumentException("EventTime is required");
        
        
        var entity = new Event
        {
            Id = Guid.NewGuid(),
            TenantId = TenantId,
            EventName = request.EventName.Trim(),
            EventTime = request.EventTime,
            Metadata = request.Metadata?.ToString(),
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };

        await _eventRepository.AddAsync(entity);

        return new EventResponse
        {
            Id = entity.Id,
            EventName = entity.EventName,
            EventTime = entity.EventTime,
            Metadata = request.Metadata
        };
    }
}