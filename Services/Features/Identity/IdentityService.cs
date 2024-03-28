using Data;
using Data.Entities;

namespace Services.Features.Identity;

public class IdentityService : IIdentityService
{
    private readonly AppDbContext _dbContext;

    public IdentityService(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public void Register(string username, string password, string email)
    {
        var newUser = new User()
        {
            Username = username,
            Password = password,
            Email = email
        };

        _dbContext.Users.Add(newUser);
        _dbContext.SaveChanges();
    }

    public string Login(string username, string password)
    {
        var user = _dbContext.Users.FirstOrDefault(x => x.Username == username);

        if (user is null)
        {
            throw new NullReferenceException();
        }

        if (user.Password != password)
        {
            throw new Exception();
        }

        return $"Secret code {user.Id}";
    }


}