using NZWalks.API.Models.Domain;

namespace NZWalks.API.Models.DTO
{
    public class Walk
    {
        public string Name { get; set; }
        public double length { get; set; }
        public Guid RegionId { get; set; }
        public Guid WalkDiffcultyId { get; set; }

        // Navigation Properties

        public Region Region { get; set; }
        public WalkDifficulty WalkDifficulty { get; set; }
    }
}
