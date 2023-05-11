using ConfluencePrototype.Models.Cards;

namespace ConfluencePrototype.Models.Events
{
    public class ExecuteEventData
        : EventData
    {
        public readonly Card Card;
        public readonly Coords Coords;

        public ExecuteEventData(Card card, Coords coords)
        {
            this.Card = card;
            this.Coords = coords;
        }
    }
}
