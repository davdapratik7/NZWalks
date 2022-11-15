using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Data;
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
        public async Task<IActionResult> GetWalkAsync(Guid id)
        {
            // get walk domin object from database
            var walk = await walkRepository.GetWalkAsync(id);

            // Convvert Domain object to DTO

            var WalkDTO = mapper.Map<Models.DTO.Walk>(walk);

            // Return response

            return Ok(WalkDTO);
        }
    }
}
