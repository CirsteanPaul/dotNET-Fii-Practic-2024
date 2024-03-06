namespace TrackLocationMVC.Data.Repositories;

public interface ILocationRepository
{ 
    AppDbContext DbContext { get; }
}