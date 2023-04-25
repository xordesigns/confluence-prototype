using ConfluencePrototype.Enums;
using ConfluencePrototype.Models.Players;

namespace ConfluencePrototype.Models.Cards
{
    internal class Lambda : Card
    {
        public readonly LambdaSubtype? Subtype;

        public Lambda(string name, CardEffect slotEffect, Player owner, LambdaSubtype? subtype = null)
            : base(name, CardType.Lambda, slotEffect, owner)
        {
            Subtype = subtype;
        }
    }
}
