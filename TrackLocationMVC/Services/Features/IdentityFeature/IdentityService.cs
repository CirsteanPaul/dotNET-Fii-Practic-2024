using TrackLocationMVC.Data.Entities;
using TrackLocationMVC.Data.Repositories;
using TrackLocationMVC.Services.Exceptions;

namespace TrackLocationMVC.Services.Features.IdentityFeature;

public class IdentityService : IIdentityService
{
    private readonly IUserRepository _userRepository;

    public IdentityService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public string Login(IdentityDto dto)
    {
        if (string.IsNullOrWhiteSpace(dto.Username) || string.IsNullOrWhiteSpace(dto.Password))
        {
            throw new BusinessException();
        }

        var user = _userRepository.GetByName(dto.Username);

        if (user is null)
        {
            throw new BusinessException();
        }

        return $"Secret code {user.Id}";
    }

    public void Register(IdentityDto dto)
    {
        if (string.IsNullOrWhiteSpace(dto.Username) || string.IsNullOrWhiteSpace(dto.Password))
        {
            throw new BusinessException();
        }
        
        var user = _userRepository.GetByName(dto.Username);

        if (user is not null)
        {
            throw new BusinessException();
        }

        var newUser = new User()
        {
            Name = dto.Username,
            Password = dto.Password,
            CreatedAt = DateTime.UtcNow
        };

        _userRepository.DbContext.Users.Add(newUser);
        _userRepository.DbContext.SaveChanges();
    }
}