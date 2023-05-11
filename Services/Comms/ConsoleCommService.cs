using ConfluencePrototype.Enums;
using ConfluencePrototype.Helpers;
using ConfluencePrototype.Models.Players;

namespace ConfluencePrototype.Services.Comms
{
    public class ConsoleCommService : ICommService
    {
        public int GetLambdaIndexFromHand(Player targetPlayer)
        {
            var lambdasFromHand = targetPlayer.Hand.Cards
                .Select((card, index) => new { Index = index, Card = card })
                .Where(card => card.Card.Type == CardType.Lambda)
                .ToList();

            if (lambdasFromHand.Count < 1)
            {
                return -1;
            }

            Console.WriteLine($"Choose a card number:");

            foreach (var lambda in lambdasFromHand)
            {
                Console.WriteLine($"{lambda.Index}: {lambda.Card.Name}");
            }

            _ = int.TryParse(Console.ReadLine(), out var input);

            return input switch
            {
                >= 0 when input < targetPlayer.Hand.Cards.Count => input,
                _ => -1
            };
        }

        public bool PlayLambdaFromHand(Player player)
        {
            if(!player.Hand.Cards.Any(card => card.Type == CardType.Lambda))
            {
                return false;
            }

            Console.WriteLine("Play Lambda from hand on this slot? Y/N");
            var input = Console.Read();
            return (input == 'Y');
        }
    }
}
