using ConfluencePrototype.Models.Cards;
using ConfluencePrototype.Models.Players;

namespace ConfluencePrototype.Models.Events
{
    public class TrashEventData
        : EventData
    {
        public readonly IZone SourceZone;
        public readonly Card Card;

        public TrashEventData(IZone sourceZone, Card card)
        {
            this.SourceZone = sourceZone;
            this.Card = card;
        }
    }
}
