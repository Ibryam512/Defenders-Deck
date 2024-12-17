using DefendersDeck.Domain.Entities;
using DefendersDeck.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace DefendersDeck.DataAccess.Seeds
{
    internal static class CardsSeed
    {
        private static readonly List<Card> cards = 
        [
            new()
            {
                Id = 1,
                Name = "Fire Arrows",
                Description = "When this card is placed, a one-time attack is activated, dealing 25 damage.",
                ImageUrl = "",
                Type = CardType.Attack,
                Amount = 25,
                Price = 50,
                Turns = 1,
                CreationDate = DateTime.Today,
            },
            new()
            {
                Id = 2,
                Name = "Earthquake",
                Description = "When this card is placed, for the next three turns, an earthquake occurs, dealing 25 damage.",
                ImageUrl = "",
                Type = CardType.Attack,
                Amount = 25,
                Price = 70,
                Turns = 3,
                CreationDate = DateTime.Today,
            },
            new()
            {
                Id = 3,
                Name = "Sound Wave",
                Description = "When this card is placed, a one-time sound wave appears, dealing 30 damage.",
                ImageUrl = "",
                Type = CardType.Attack,
                Amount = 30,
                Price = 60,
                Turns = 1,
                CreationDate= DateTime.Today,
            },
            new()
            {
                Id = 4,
                Name = "Fullmetal Alchemy",
                Description = "When this card is placed, a metal wall is generated, protecting against 20 damage",
                ImageUrl = "",
                Type = CardType.Defense,
                Amount = 20,
                Price = 80,
                Turns = 1,
                CreationDate = DateTime.Today
            },
            new()
            {
                Id = 5,
                Name = "Water Shield",
                Description = "When this card is placed, a water shield appears for one turn, absorbing up to 50 attack damage.",
                ImageUrl = "",
                Type = CardType.Defense,
                Amount = 50,
                Price = 100,
                Turns = 1,
                CreationDate = DateTime.Today
            },
            new()
            {
                Id = 6,
                Name = "First Aid",
                Description = "When this card is placed, the tower restores 30 health as a one-time effect.",
                ImageUrl = "",
                Type = CardType.Healing,
                Amount = 30,
                Price = 40,
                Turns = 1,
                CreationDate = DateTime.Today
            },
            new()
            {
                Id = 7,
                Name = "Special Help",
                Description = "When this card is placed, it restores 20 health per turn for three turns.",
                ImageUrl = "",
                Type = CardType.Healing,
                Amount = 20,
                Price = 70,
                Turns = 3,
                CreationDate = DateTime.Today
            },
            new()
            {
                Id = 8,
                Name = "Health Potion",
                Description = "When this card is placed, the tower's entire health is restored as a one-time effect.",
                ImageUrl = "",
                Type = CardType.Healing,
                Amount = 100,
                Price = 120,
                Turns = 1,
                CreationDate = DateTime.Today
            },
            new()
            {
                Id = 9,
                Name = "Shadow Army",
                Description = "When this card is placed, all dead enemies reappear as shadows and attack the living enemies. Shadows disappear when they kill an enemy.",
                ImageUrl = "",
                Type = CardType.Ultimate,
                Amount = 0,
                Price = 150,
                Turns = 1,
                CreationDate = DateTime.Today
            }
        ];

        public static void SeedCards(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Card>().HasData(cards);
        }
    }
}
