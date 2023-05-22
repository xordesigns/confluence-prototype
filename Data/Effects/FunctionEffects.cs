using ConfluencePrototype.Helpers;
using ConfluencePrototype.Models.Cards;
using System.Runtime.Versioning;
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

        public static readonly CardEffect Struct = new
        (
            startSlot: 1,
            endSlot: 3,
            rulesText: "You may install a Function from hand. If you do, draw a card.",
            effect: (match, sourcePlayer, commService, slotNumber) =>
            {
                var optionalInstallAnswer = commService.GetYouMayResult("Install a Function from hand");

                if (optionalInstallAnswer)
                {
                    var targetFunctionFromHandIndex = commService.GetCardIndexFromHand(sourcePlayer, Enums.CardType.Function);

                    if (targetFunctionFromHandIndex < 0)
                    {
                        return;
                    }

                    var targetSlotCoords = commService.GetSlotCoordinates(sourcePlayer);

                    var targetSlot = match.GetSlotFromCoords(targetSlotCoords);

                    Install(match, sourcePlayer.Hand.Cards[targetFunctionFromHandIndex], sourcePlayer.Hand, sourcePlayer, targetSlot);

                    Draw(match, sourcePlayer.Deck.Cards[0], sourcePlayer, sourcePlayer.Deck);
                }   
            }
        );
    }
}
