using DotNetAuthSample.Api.Models;

namespace DotNetAuthSample.Api.Services
{
    public interface IJwtService
    {
        string GenerateToken(User user, IEnumerable<string> roles);
    }
}
