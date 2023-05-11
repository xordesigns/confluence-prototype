using ConfluencePrototype.Enums;
using ConfluencePrototype.Models.Players;

namespace ConfluencePrototype.Models.Cards
{
    public class Function : Card
    {
        public readonly FunctionSubtype? Subtype;
        public readonly CardEffect InterruptEffect;

        public Function(string name, CardEffect effect, CardEffect interruptEffect, Player owner, FunctionSubtype? subtype = null)
            : base(name, CardType.Function, effect, owner)
        {
            Subtype = subtype;
            InterruptEffect = interruptEffect;
        }
    }
}
