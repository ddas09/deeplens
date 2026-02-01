using DeepLens.Common.Models.Request;
using DeepLens.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DeepLens.Api.Controllers;

/// <summary>
/// Controller responsible for managing events.
/// </summary>
[ApiController]
[Route("api/events")]
public class EventsController : ControllerBase
{
    private readonly IEventService _eventService;
    
    public EventsController(IEventService eventService)
    {
        _eventService = eventService;
    }
    
    /// <summary>
    /// Ingests a new event.
    /// </summary>
    /// <param name="request">The request containing information of the event to ingest.</param>
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] EventIngestRequest request)
    {
        try
        {
            var createdEvent = await _eventService.IngestEvent(request);
            return Created
            (
                $"/api/events/{createdEvent.Id}",
                createdEvent
            );
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new
            {
                error = ex.Message
            });
        }
    }
}