namespace NZWalks.API.Models.Domain
{
    public class WalkDifficulty
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public double Area { get; set; }
        public double lat { get; set; }
        public double Long { get; set; }
        public long Population { get; set; }

        // Navigation Property
        public IEnumerable<Walk> Walks { get; set; }

    }
}
