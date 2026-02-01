using DeepLens.Common.Models.Request;
using DeepLens.Common.Models.Response;

namespace DeepLens.Services.Interfaces;

public interface IEventService
{
    Task<EventResponse> IngestEvent(EventIngestRequest request);
}