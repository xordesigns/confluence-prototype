using ConfluencePrototype.Enums;
using ConfluencePrototype.Models.Cards;

namespace ConfluencePrototype.Models.Players
{
    internal class Player
    {
        public string Name;

        public Zone Hand;
        public Zone Deck;
        public Zone Trash;

        public Player(string name)
        {
            this.Name = name;

            this.Hand = new(ZoneType.Hand, new List<Card>());
            this.Deck = new(ZoneType.Deck, new List<Card>());
            this.Trash = new(ZoneType.Trash, new List<Card>());
        }
    }
}
