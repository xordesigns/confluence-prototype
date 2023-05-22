using ConfluencePrototype.Models.Cards;
using static ConfluencePrototype.Helpers.Effects;

namespace ConfluencePrototype.Data.Effects
{
    public static class InterruptEffects
    {
        public static readonly CardEffect Placeholder = new
        (
            startSlot: 1,
            endSlot: 3,
            rulesText: "Draw a card",
            effect: (match, sourcePlayer, commService, slotNumber) =>
            {
                Draw(match, sourcePlayer.Deck.Cards[0], sourcePlayer, sourcePlayer.Deck);
            }
        );
    }
}
