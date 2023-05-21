using ConfluencePrototype.Enums;
using ConfluencePrototype.Models.Cards;

namespace ConfluencePrototype.Models.Players
{
    public interface IZone
    {
        public ZoneType Type { get; }

        public void Add(Card card);

        public bool Remove(Card card);
    }
}
