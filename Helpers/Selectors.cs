using ConfluencePrototype.Enums;
using ConfluencePrototype.Models;
using ConfluencePrototype.Models.Cards;
using ConfluencePrototype.Models.Players;

namespace ConfluencePrototype.Helpers
{
    internal static class Selectors
    {
        public static IEnumerable<Card> InstalledNonInteruptForPlayer(Match match, Player player)
        {
            var cards = match.AllPrograms
                .SelectMany(prog => prog.Slots)
                .Where(slot => slot.Owner == player)
                .Select(slot => slot.InstalledCard)
                .OfType<Card>();

            return cards;
        }

        public static IEnumerable<Card> AllInstalledForPlayer(Match match, Player player)
        {
            return InstalledNonInteruptForPlayer(match, player)
                .Concat(AllInterruptsForPlayer(match, player));
        }

        public static IEnumerable<Card> AllInstalled(Match match)
        {
            return match.AllPrograms
                .SelectMany(prog => prog.Slots)
                .Select(slot => slot.InstalledCard)
                .OfType<Card>();
        }

        public static IEnumerable<Card> InZone(this IEnumerable<Card> origin, IEnumerable<Card> targetZone)
        {
            return origin.Concat(targetZone);
        }

        public static IEnumerable<Card> WithType(this IEnumerable<Card> origin, CardType type)
        {
            return origin.Where(card => card?.Type == type);
        }

        public static IEnumerable<Card> AllInterruptsForPlayer(Match match, Player player)
        {
            var interrupts = match.AllPrograms
                .SelectMany(prog => prog.Slots)
                .Where(slot => slot.Owner != player)
                .Select(slot => slot.Interrupt)
                .OfType<Function>();

            return interrupts;
        }

        public static IEnumerable<Card> InterruptsForPlayerByState(Match match, Player player, bool isLocked)
        {
            var interrupts = match.AllPrograms
                .SelectMany(prog => prog.Slots)
                .Where(slot => slot.Owner != player
                        && slot.InterruptLocked == isLocked)
                .Select(slot => slot.Interrupt)
                .OfType<Function>();

            return interrupts;
        }

        public static IEnumerable<Card> AllInstalledFunctionsForPlayer(Match match, Player player)
        {
            var functions = match.AllPrograms
                .SelectMany(prog => prog.Slots)
                .Where(slot => slot.Owner == player)
                .Select(slot => slot.InstalledCard)
                .OfType<Function>();

            return functions;
        }

        public static IEnumerable<Card> AllFunctionsInColumnForPlayer(Match match, Player player, int column)
        {
            var allSlotsForPlayer = match.AllPrograms
                .SelectMany(prog => prog.Slots)
                .Where(slot => slot.Owner == player);

            return column switch
            {
                1 or 2 or 3 => allSlotsForPlayer.Where(slot => slot.Coords.Slot == column).Select(slot => slot.InstalledCard).OfType<Function>(),
                _ => throw new Exception("No such column exists!")
            };
        }
    }
}
