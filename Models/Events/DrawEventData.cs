using ConfluencePrototype.Models.Cards;

namespace ConfluencePrototype.Models.Events
{
    public class DrawEventData
        : EventData
    {
        public readonly Card Card;

        public DrawEventData(Card card)
        {
            this.Card = card;
        }
    }
}
