using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Data;
using NZWalks.API.Models.DTO;
using NZWalks.API.Repositories;

namespace NZWalks.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WalkController : Controller
    {
        private readonly IWalkRepository walkRepository;
        private readonly IMapper mapper;

        public WalkController(IWalkRepository walkRepository, IMapper mapper)
        {
            this.walkRepository = walkRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllWalkAsync()
        {
            // Fetch Data from Database - domain walks
            var walk = await walkRepository.GetAllWalkAsync();

            // Convert domain walks to DTO Walks

            var walkDTO = mapper.Map<List<Models.DTO.Walk>>(walk);
            return Ok(walkDTO);
        }

        [HttpGet]
        [Route("{id:guid}")]
        [ActionName("GetWalkAsync")]
        public async Task<IActionResult> GetWalkAsync(Guid id)
        {
            // get walk domin object from database
            var walk = await walkRepository.GetWalkAsync(id);

            // Convvert Domain object to DTO

            var WalkDTO = mapper.Map<Models.DTO.Walk>(walk);

            // Return response

            return Ok(WalkDTO);
        }

        [HttpPost]
        public async Task<IActionResult> AddWalkAsync([FromBody] Models.DTO.AddWalkRequest addWalkRequest)
        {
            // Convert DTO to Domain Object

            var WalkDomain = new Models.Domain.Walk
            {
                length = addWalkRequest.length,
                Name = addWalkRequest.Name,
                RegionId = addWalkRequest.RegionId,
                WalkDifficultyId = addWalkRequest.WalkDifficultyId
            };

            // Pass domain object to repository to presist this
            WalkDomain = await walkRepository.AddAsync(WalkDomain);

            // Convert the Domain object back to DTO
            var WalkDTO = new Models.DTO.Walk
            {
                Id = WalkDomain.Id,
                Name = WalkDomain.Name,
                length = WalkDomain.length,
                RegionId = WalkDomain.RegionId,
                WalkDifficultyId = WalkDomain.WalkDifficultyId
            };

            // Send DTO response back to Client
            return CreatedAtAction(nameof(GetWalkAsync), new { id = WalkDTO.Id }, WalkDTO);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateWalkAsync([FromRoute] Guid id, [FromBody] Models.DTO.UpdateWalkRequest updateWalkRequest)
        {
            // Convert DTO to Domain object

            var WalkDomain = new Models.Domain.Walk
            {
                length = updateWalkRequest.length,
                Name = updateWalkRequest.Name,
                RegionId = updateWalkRequest.RegionId,
                WalkDifficultyId = updateWalkRequest.WalkDifficultyId
            };
            // Pass details to Repository - Get Domain object in response (or null)
            WalkDomain = await walkRepository.UpdateAsync(id, WalkDomain);
            // Handle Null (not found)
            if (WalkDomain == null)
            {
                return NotFound();
            }

            // Convert back Domain to DTO
            var WalkDTO = new Models.DTO.Walk
            {
                Id = WalkDomain.Id,
                Name = WalkDomain.Name,
                length = WalkDomain.length,
                RegionId = WalkDomain.RegionId,
                WalkDifficultyId = WalkDomain.WalkDifficultyId
            };

            // Return Response
            return Ok(WalkDTO);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteWalkAsync([FromRoute] Guid id)
        {
            var walkDomain = await walkRepository.DeleteAsync(id);
            if (walkDomain == null)
            {
                return NotFound();
            }

            var WalkDTO = mapper.Map<Models.DTO.Walk>(walkDomain);

            return Ok(WalkDTO);
        }
    }
}
