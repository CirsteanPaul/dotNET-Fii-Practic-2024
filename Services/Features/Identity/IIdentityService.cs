namespace Services.Features.Identity;

public interface IIdentityService
{
    string Login(string username, string password);
    void Register(string username, string password, string email);
}