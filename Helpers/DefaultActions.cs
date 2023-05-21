using ConfluencePrototype.Models;
using ConfluencePrototype.Models.Players;
using ConfluencePrototype.Services.Comms;

namespace ConfluencePrototype.Helpers
{
    public static class DefaultActions
    {
        public delegate void DefaultAction(Match match, Player player, ICommService commService);

        public static readonly DefaultAction Draw = (match, player, commService) =>
        {
            if (player.Memory > 0)
            {
                player.Memory -= 1;
                Effects.Draw(match, player.Deck.Cards[0], player, player.Deck);
            }
        };

        public static readonly DefaultAction Install = (match, player, commService) =>
        {
            if (player.Memory > 0)
            {
                player.Memory -= 1;

                var cardIndexToPlay = commService.GetCardIndexFromHand(player);

                if (cardIndexToPlay != -1)
                {
                    var coords = commService.GetSlotCoordinates(player);
                    Effects.Install(match, player.Hand.Cards[cardIndexToPlay], player.Hand, player, coords.Slot);
                }

            }
        };
    }
}
