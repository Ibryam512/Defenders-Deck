namespace DefendersDeck.Domain.Entities
{
    public class Difficulty : BaseEntity
    {
        public required string Name { get; set; }
        public int EnemiesCount { get; set; }
        public required string CardsPropability { get; set; }
        public int EnemyLevelId { get; set; }
        public required EnemyLevel EnemyLevel { get; set; }
        public int TowerLevelId { get; set; }
        public required TowerLevel TowerLevel { get; set; }
    }
}
