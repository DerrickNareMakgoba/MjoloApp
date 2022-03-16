using API.Models;

namespace API.Interfaces
{
    public interface ITokenService
    {
         string createToken(AppUser user);
    }
}