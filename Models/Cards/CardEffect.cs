using ConfluencePrototype.Models.Players;
using ConfluencePrototype.Services.Comms;

namespace ConfluencePrototype.Models.Cards
{
    public class CardEffect
    {
        public delegate void CardEffectDelegate(Match match, Player sourcePlayer, ICommService commService, Coords coords);

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

        public void Execute(Match match, Player sourcePlayer, ICommService commService, Coords coords)
        {
           this.Effect.Invoke(match, sourcePlayer, commService, coords);
        }
    }
}
