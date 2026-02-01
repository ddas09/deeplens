using System.Text.Json;

namespace DeepLens.Common.Models.Request;

public class EventIngestRequest
{
    public string EventName { get; set; } 
    
    public DateTime EventTime { get; set; }
    
    public JsonElement? Metadata { get; set; }
}