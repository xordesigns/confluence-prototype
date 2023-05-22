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
                .Concat(InterruptsForPlayer(match, player));
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

        public static IEnumerable<Card> InterruptsForPlayer(Match match, Player player)
        {
            var interrupts = match.AllPrograms
                .SelectMany(prog => prog.Slots)
                .Where(slot => slot.Owner != player)
                .Select(slot => slot.Interrupt)
                .OfType<Function>();

            return interrupts;
        }
    }
}
