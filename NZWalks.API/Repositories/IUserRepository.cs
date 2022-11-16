
using NZWalks.API.Models.Domain;

namespace NZWalks.API.Repositories
{
    public interface IUserRepository
    {
       Task<user> AuthenticateAsync(string username, string password);
    }
}
