using DeepLens.DAL.Interfaces;
using DeepLens.Data;
using DeepLens.Data.Entities;

namespace DeepLens.DAL.Repositories;

public class EventRepository : BaseRepository<Event>, IEventRepository
{
    public EventRepository(DeepLensDBContext context) 
        : base(context)
    {
    }
}