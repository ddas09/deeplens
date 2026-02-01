using System.Text.Json;

namespace DeepLens.Common.Models.Response;

public class EventResponse
{
    public Guid Id { get; set; }
    
    public string EventName { get; set; }
    
    public DateTime EventTime { get; set; }
    
    public JsonElement? Metadata { get; set; }
}