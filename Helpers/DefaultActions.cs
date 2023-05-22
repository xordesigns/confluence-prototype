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
                    var targetSlot = match.GetSlotFromCoords(coords);
                    Effects.Install(match, player.Hand.Cards[cardIndexToPlay], player.Hand, player, targetSlot);
                }

            }
        };

        public static readonly DefaultAction InstallInterrupt = (match, player, commService) =>
        {
            if (player.Memory > 0)
            {
                player.Memory -= 1;

                var cardIndexToPlay = commService.GetCardIndexFromHand(player, Enums.CardType.Function);

                if (cardIndexToPlay != -1)
                {
                    var opponent = match.Players[(player.Id + 1) % 2];
                    var coords = commService.GetInterruptSlotCoordinates(opponent);
                    var targetSlot = match.GetSlotFromCoords(coords);
                    Effects.InstallInterrupt(match, player.Hand.Cards[cardIndexToPlay], player.Hand, player, targetSlot);
                }
            }
        };

        public static readonly DefaultAction TrashInterrupt = (match, player, commService) =>
        {
            if (player.Memory > 0)
            {
                player.Memory -= 1;

                var opponent = match.Players[(player.Id + 1) % 2];

                var opponentInstalledInterrupts = Selectors.InterruptsForPlayer(match, opponent)
                    .ToList();

                if (opponentInstalledInterrupts.Any())
                {
                    var targetCardIndex = commService.GetCardIndexFromList(opponentInstalledInterrupts);
                    Effects.Trash(match, player, player.Trash, opponentInstalledInterrupts[targetCardIndex]);
                }
            }
        };

        public static readonly DefaultAction RunProgram = (match, player, commService) =>
        {
            var programNumber = commService.GetProgramIndex();

            if (player.Memory >= programNumber)
            {
                player.Memory -= programNumber;

                match.GetProgramFromNumber(player, programNumber).Execute(match, commService);
            }
        };
    }
}
