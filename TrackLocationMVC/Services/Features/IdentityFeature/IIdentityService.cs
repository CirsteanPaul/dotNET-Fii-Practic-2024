namespace TrackLocationMVC.Services.Features.IdentityFeature;

public interface IIdentityService
{
    string Login(IdentityDto dto);
    void Register(IdentityDto dto);
}