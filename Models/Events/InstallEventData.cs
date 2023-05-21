using ConfluencePrototype.Models.Cards;
using ConfluencePrototype.Models.Programs;

namespace ConfluencePrototype.Models.Events
{
    public class InstallEventData
        : EventData
    {
        public readonly Card Card;
        public readonly Slot TargetSlot;

        public InstallEventData(Card card, Slot targetSlot)
        {
            this.Card = card;
            this.TargetSlot = targetSlot;
        }
    }
}
