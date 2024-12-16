namespace DefendersDeck.Domain.Entities
{
    public class User : BaseEntity
    {
        public required string Username { get; set; }
        public required string PasswordHash { get; set; }
        public required string ProfileImageUrl { get; set; }
        public int CurrencyAmount { get; set; }

        public List<Card> Cards { get; set; } = [];
    }
}
