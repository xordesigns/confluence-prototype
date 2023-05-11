using ConfluencePrototype.Models.Cards;
using ConfluencePrototype.Models.Players;

namespace ConfluencePrototype.Models.Events
{
    public class MoveEventData
        : EventData
    {
        public readonly IZone Source;
        public readonly IZone Destination;
        public readonly Card Card;

        public MoveEventData(IZone source, IZone destination, Card card)
        {
            this.Source = source;
            this.Destination = destination;
            this.Card = card;
        }
    }
}
