using ConfluencePrototype.Enums;
using ConfluencePrototype.Models.Cards;

namespace ConfluencePrototype.Models.Players
{
    public class Player
    {
        public string Name;

        public Hand Hand;
        public Deck Deck;
        public Trash Trash;

        public Player(string name, List<Card> deck)
        {
            this.Name = name;

            this.Hand = new();
            this.Deck = new(deck);
            this.Trash = new();
        }
    }
}
