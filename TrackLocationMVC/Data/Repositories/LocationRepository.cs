using TrackLocationMVC.Data.Entities;

namespace TrackLocationMVC.Data.Repositories;

public class LocationRepository : ILocationRepository
{
    public LocationRepository(AppDbContext dbContext)
    {
        DbContext = dbContext;
    }

    public AppDbContext DbContext { get; }
}