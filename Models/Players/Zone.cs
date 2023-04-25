using ConfluencePrototype.Enums;
using ConfluencePrototype.Models.Cards;

namespace ConfluencePrototype.Models.Players
{
    internal class Zone
    {
        public readonly ZoneType Type;
        public List<Card> Cards;

        public Zone(ZoneType type, List<Card> cards)
        {
            this.Type = type;
            this.Cards = cards;
        }
    }
}
