using ConfluencePrototype.Models;
using ConfluencePrototype.Models.Cards;
using ConfluencePrototype.Models.Players;

namespace ConfluencePrototype.Helpers
{
    internal static class Actions
    {
        public static void MoveCardToZone(Match match, Zone source, Zone destination, Card card)
        {
            if (source.Cards.Remove(card))
            {
                destination.Cards.Add(card);
            }

            match.HandleEvent($"Moved {card.Name} from {source.Type} to {destination.Type}");
        }
    }
}
