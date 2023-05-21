using ConfluencePrototype.Models.Cards;

namespace ConfluencePrototype.Models.Players
{
    public class Player
    {
        public string Name;

        public int Memory;

        public Hand Hand;
        public Deck Deck;
        public Trash Trash;

        public readonly List<Action> DefaultActions;

        public Player(string name, List<Card> deck)
        {
            this.Name = name;

            this.Memory = 10;

            this.Hand = new();
            this.Deck = new(deck);
            this.Trash = new();

            this.DefaultActions = new();
        }
    }
}
