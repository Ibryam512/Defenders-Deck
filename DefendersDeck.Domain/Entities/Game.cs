namespace DefendersDeck.Domain.Entities
{
    public class Game : BaseEntity
    {
        public int Duration { get; set; }
        public int EnemiesKilled { get; set; }
        public int UserId { get; set; }
        public required User User { get; set; }

        public List<Card> Cards { get; set; } = [];
    }
}
