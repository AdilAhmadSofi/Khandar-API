using Khandar.Domain.Entities;

namespace Khandar.Application.Abstractions.JWT;

public interface IJwtProvider
{
    public string GenerateToken(User user);
}
