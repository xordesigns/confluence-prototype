using ConfluencePrototype.Enums;
using ConfluencePrototype.Models.Cards;

namespace ConfluencePrototype.Models.Players
{
    public class Deck
        : IZone
    {
        public List<Card> Cards;

        public ZoneType Type => ZoneType.Deck;

        public Deck(List<Card> cards)
        {
            this.Cards = cards;
        }

        public void Add(Card card)
        {
            this.Cards.Add(card);
        }

        public bool Remove(Card card)
        {
            return this.Cards.Remove(card);
        }
    }
}
