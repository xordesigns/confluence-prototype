using ConfluencePrototype.Models.Cards;
using static ConfluencePrototype.Helpers.Effects;

namespace ConfluencePrototype.Data.Effects
{
    public static class FunctionEffects
    {
        public static readonly CardEffect Obelisk = new
        (
            startSlot: 2,
            endSlot: 3,
            rulesText: "Draw <2/3> cards",
            effect: (match, sourcePlayer, commService, slotNumber) => 
                {
                    if (slotNumber is 2 or 3)
                    {
                        for (int i = 0; i < slotNumber; i++)
                        {
                            var topCard = sourcePlayer.Deck.Cards[0];
                            Draw(match, topCard, sourcePlayer, sourcePlayer.Deck);
                        }
                    }
                }
        );
    }
}
