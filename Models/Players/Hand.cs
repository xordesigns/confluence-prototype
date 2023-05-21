using ConfluencePrototype.Enums;
using ConfluencePrototype.Models.Cards;

namespace ConfluencePrototype.Models.Players
{
    public class Hand
        : IZone
    {
        public List<Card> Cards;

        public ZoneType Type => ZoneType.Hand;

        public Hand()
        {
            this.Cards = new();
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
