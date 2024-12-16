namespace DefendersDeck.Domain.Entities
{
    public class EnemyLevel : BaseEntity
    {
        public int Health { get; set; }
        public int Power { get; set; }
        public required string DesignUrl { get; set; }
        public int DifficultyId { get; set; }
        public required Difficulty Difficulty { get; set; }
    }
}
