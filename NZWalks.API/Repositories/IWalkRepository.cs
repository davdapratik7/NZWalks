using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Models.Domain;

namespace NZWalks.API.Repositories
{
    public interface IWalkRepository
    {
        Task<IEnumerable<Walk>> GetAllWalkAsync();
        Task<Walk> GetWalkAsync(Guid id);
        Task<Walk> AddAsync(Walk walk);
        Task<Walk> DeleteAsync(Guid id);
        Task<Walk> UpdateAsync(Guid id, Walk walk);
    }
}
