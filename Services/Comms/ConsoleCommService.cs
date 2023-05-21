using ConfluencePrototype.Enums;
using ConfluencePrototype.Models;
using ConfluencePrototype.Models.Players;
using System.Text.RegularExpressions;

namespace ConfluencePrototype.Services.Comms
{
    public class ConsoleCommService : ICommService
    {
        public int GetCardIndexFromHand(Player targetPlayer, CardType? targetType = null)
        {
            var filteredCards = targetPlayer.Hand.Cards
                .Select((card, index) => new { Index = index, Card = card })
                .ToList();

            if (targetType is not null)
            {
                filteredCards = filteredCards
                    .Where(card => card.Card.Type == targetType)
                    .ToList();
            }

            if (filteredCards.Count < 1)
            {
                return -1;
            }

            Console.WriteLine($"Choose a card number:");

            foreach (var lambda in filteredCards)
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

        public Coords GetSlotCoordinates(Player targetPlayer)
        {
            var coordsPattern = new Regex(@"(\d)\\/(\d)");

            while (true)
            {
                Console.WriteLine("Input target slot in the format X/Y:");
                var match = coordsPattern.Match(Console.ReadLine());

                if (match is null)
                {
                    continue;
                }
                else
                {
                    int program = int.Parse(match.Groups[0].Value);
                    int slot = int.Parse(match.Groups[1].Value);
                    return new Coords(program, slot);
                }
            }
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
