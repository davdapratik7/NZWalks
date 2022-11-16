using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Models.DTO;
using NZWalks.API.Repositories;

namespace NZWalks.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WalkDifficultiesController : Controller
    {
        private readonly IWalkDifficultyRepository walkDifficultyRepository;
        private readonly IMapper mapper;

        public WalkDifficultiesController(IWalkDifficultyRepository walkDifficultyRepository, IMapper mapper)
        {
            this.walkDifficultyRepository = walkDifficultyRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var WalkDifficultyDomain = await walkDifficultyRepository.GetAllAsync();

            if (WalkDifficultyDomain == null)
            {
                return NotFound();
            }

            var WalkDifficultyDTO = mapper.Map<List<Models.DTO.WalkDifficulty>>(WalkDifficultyDomain);

            return Ok(WalkDifficultyDTO);
        }

        [HttpGet]
        [Route("{id:guid}")]
        [ActionName("GetWalkDifficultyById")]
        public async Task<IActionResult> GetWalkDifficultyById(Guid id)
        {
            var WalkDifficultyDomain = await walkDifficultyRepository.GetAsync(id);

            if (WalkDifficultyDomain == null)
            {
                return NotFound();
            }
            var WalkDifficultyDTO = mapper.Map<Models.DTO.WalkDifficulty>(WalkDifficultyDomain);

            return Ok(WalkDifficultyDTO);
        }

        [HttpPost]
        public async Task<IActionResult> AddWalkDifficultyAsync([FromBody] Models.DTO.AddWalkDifficulty addWalkDifficulty)
        {
            // Validate the request

            if (!ValidateAddWalkDifficultyAsync(addWalkDifficulty))
            {
                return BadRequest(ModelState);
            }
            
            // Convert DTO to Domain Model
            var WalkDifficultyDomain = new Models.Domain.WalkDifficulty
            {
                Code = addWalkDifficulty.Code
            };

            // Call repository
            WalkDifficultyDomain = await walkDifficultyRepository.AddAsync(WalkDifficultyDomain);

            // Convert Domain to DTO
            var WalkDifficultyDTO = mapper.Map<Models.DTO.WalkDifficulty>(WalkDifficultyDomain);

            //  Return response
            return CreatedAtAction(nameof(GetWalkDifficultyById),
                new { id = WalkDifficultyDTO.Id }, WalkDifficultyDTO);

        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateWalkDifficultyAsync(Guid id, Models.DTO.UpdateWalkDifficulty updateWalkDifficulty)
        {
            // Validate the request

            if (!ValidateUpdateWalkDifficultyAsync(updateWalkDifficulty))
            {
                return BadRequest(ModelState);
            }

            // Convert DTO to Domain Model
            var WalkDifficultyDomain = new Models.Domain.WalkDifficulty
            {
                Code = updateWalkDifficulty.Code
            };

            // Call repository
            WalkDifficultyDomain = await walkDifficultyRepository.UpdateAsync(id, WalkDifficultyDomain);

            if (updateWalkDifficulty == null)
            {
                return NotFound();
            }
            // Convert Domain to DTO
            var WalkDifficultyDTO = mapper.Map<Models.DTO.WalkDifficulty>(WalkDifficultyDomain);

            //  Return response
            return Ok(WalkDifficultyDTO);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteWalkDifficultyAsync(Guid id)
        {
            // Call repository
            var WalkDifficultyDomain = await walkDifficultyRepository.DeleteAsync(id);

            if (WalkDifficultyDomain == null)
            {
                return NotFound();
            }
            // Convert Domain to DTO
            var WalkDifficultyDTO = mapper.Map<Models.DTO.WalkDifficulty>(WalkDifficultyDomain);

            //  Return response
            return Ok(WalkDifficultyDTO);
        }

        #region Private methods
        private bool ValidateAddWalkDifficultyAsync(Models.DTO.AddWalkDifficulty addWalkDifficulty)
        {
            if (addWalkDifficulty == null)
            {
                ModelState.AddModelError(nameof(addWalkDifficulty), $"Add WalkDifficulty Data is required.");
                return false;
            }
            if (string.IsNullOrWhiteSpace(addWalkDifficulty.Code))
            {
                ModelState.AddModelError(nameof(addWalkDifficulty.Code),
                    $"{nameof(addWalkDifficulty.Code)} can't be null or empty or white space.");
            }

            if (ModelState.ErrorCount > 0)
            {
                return false;
            }

            return true;

        }
        private bool ValidateUpdateWalkDifficultyAsync(Models.DTO.UpdateWalkDifficulty updateWalkDifficulty)
        {
            if (updateWalkDifficulty == null)
            {
                ModelState.AddModelError(nameof(updateWalkDifficulty), $"Add WalkDifficulty Data is required.");
                return false;
            }
            if (string.IsNullOrWhiteSpace(updateWalkDifficulty.Code))
            {
                ModelState.AddModelError(nameof(updateWalkDifficulty.Code),
                    $"{nameof(updateWalkDifficulty.Code)} can't be null or empty or white space.");
            }

            if (ModelState.ErrorCount > 0)
            {
                return false;
            }

            return true;

        }
        #endregion
    }
}
