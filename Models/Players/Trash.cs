using ConfluencePrototype.Enums;
using ConfluencePrototype.Models.Cards;

namespace ConfluencePrototype.Models.Players
{
    public class Trash
        : IZone
    {
        public List<Card> Cards;

        public ZoneType Type => ZoneType.Trash;

        public Trash()
        {
            this.Cards = new();
        }

        public void Add(Card card)
        {
            this.Cards.Insert(0, card);
        }

        public bool Remove(Card card)
        {
            return this.Cards.Remove(card);
        }
    }
}
