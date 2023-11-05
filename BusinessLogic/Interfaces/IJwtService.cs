using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace Core.Interfaces
{
    public interface IJwtService
    {
        IEnumerable<Claim> GetClaims(IdentityUser user);
        string CreateToken(IEnumerable<Claim> claims);
    }
}