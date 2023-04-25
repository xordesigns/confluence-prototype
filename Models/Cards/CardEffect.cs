using ConfluencePrototype.Services.Comms;

namespace ConfluencePrototype.Models.Cards
{
    internal class CardEffect
    {
        public delegate void CardEffectDelegate(ICommService commService, int slotNumber);

        public readonly int StartSlot;
        public readonly int EndSlot;
        public readonly string RulesText;
        private readonly CardEffectDelegate Effect;

        public CardEffect(int startSlot, int endSlot, string rulesText, CardEffectDelegate effect)
        {
            this.StartSlot = startSlot;
            this.EndSlot = endSlot;
            this.RulesText = rulesText;
            this.Effect = effect;
        }

        public void ExecuteEffect(ICommService commService, int installedSlotNumber = -1)
        {
           this.Effect.Invoke(commService, installedSlotNumber);
        }
    }
}
