using ConfluencePrototype.Models.Cards;
using static ConfluencePrototype.Helpers.Effects;

namespace ConfluencePrototype.Data.Effects
{
    public static class LambdaEffects
    {
        public static readonly CardEffect Fetch = new
        (
            startSlot: 1,
            endSlot: 3,
            rulesText: "Draw 2 cards",
            effect: (match, sourcePlayer, commService, slotNumber) =>
            {
                for (int i = 0; i < 2; i++)
                {
                    var topCard = sourcePlayer.Deck.Cards[0];
                    Draw(match, topCard, sourcePlayer, sourcePlayer.Deck);
                }
            }
        );
    }
}
