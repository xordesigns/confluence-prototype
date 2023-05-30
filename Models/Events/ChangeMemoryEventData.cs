namespace ConfluencePrototype.Models.Events
{
    public class ChangeMemoryEventData
        : EventData
    {
        public readonly int Amount;

        public ChangeMemoryEventData(int amount)
        {
            this.Amount = amount;
        }
    }
}
