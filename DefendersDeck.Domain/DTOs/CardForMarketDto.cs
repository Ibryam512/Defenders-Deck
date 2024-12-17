namespace DefendersDeck.Domain.DTOs
{
    public class CardForMarketDto
    {
        public required CardDto Card { get; set; }
        public bool InDeck { get; set; }
    }
}
