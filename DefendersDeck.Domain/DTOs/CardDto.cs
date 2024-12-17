using DefendersDeck.Domain.Enums;

namespace DefendersDeck.Domain.DTOs
{
    public class CardDto
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public required string ImageUrl { get; set; }
        public CardType Type { get; set; }
        public int Amount { get; set; }
        public int Price { get; set; }
        public int Turns { get; set; }
    }
}
