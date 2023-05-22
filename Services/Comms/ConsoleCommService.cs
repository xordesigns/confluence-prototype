using ConfluencePrototype.Enums;
using ConfluencePrototype.Models;
using ConfluencePrototype.Models.Cards;
using ConfluencePrototype.Models.Players;
using System.Text.RegularExpressions;
using Match = ConfluencePrototype.Models.Match;

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

        public int GetCardIndexFromList(List<Card> cardList)
        {
            Console.WriteLine("Please select a card index from this list:");
            for (int i = 0; i < cardList.Count; i++)
            {
                Console.WriteLine($"{i}. {cardList[i].Name}");
            }

            int index = -1;

            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out index))
                {
                    break;
                }
            }

            return index;
        }

        public Coords GetInterruptSlotCoordinates(Player targetPlayer)
        {
            var coordsPattern = new Regex(@"(\d)\\/(\d)");

            while (true)
            {
                Console.WriteLine("Input target slot 2 or 3 from a program in the format X/Y:");
                var match = coordsPattern.Match(Console.ReadLine());

                if (match is null)
                {
                    continue;
                }
                else
                {
                    int program = int.Parse(match.Groups[0].Value);
                    int slot = int.Parse(match.Groups[1].Value);

                    if (Coords.AreInterruptCoordsValid(program, slot) is false)
                    {
                        continue;
                    }

                    return new Coords(targetPlayer.Id, program, slot);
                }
            }
        }

        public int GetProgramIndex()
        {
            Console.WriteLine("Please input a program number:");

            int index = -1;

            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out index))
                {
                    if (index is > 3 or < 1){
                        continue;
                    }
                    
                    break;
                }
            }

            return index;
        }

        public Coords GetSlotCoordinates(Player targetPlayer)
        {
            var coordsPattern = new Regex(@"(\d)/(\d)");

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
                    int program = int.Parse(match.Groups[1].Value);
                    int slot = int.Parse(match.Groups[2].Value);
                    return new Coords(targetPlayer.Id, program, slot);
                }
            }
        }

        public bool GetYouMayResult(string prompt)
        {
            Console.WriteLine($"You may {prompt}. Y/N?");

            var answer = string.Empty;

            while (true)
            {
                answer = Console.ReadLine();
                if (answer!.ToUpper() is "Y" or "N")
                {
                    break;
                }
            }

            return answer!.ToUpper() == "Y";
        }

        public void PerformDefaultAction(Match match, Player sourcePlayer)
        {
            var defaultActionNames = new List<string>
            {
                "Draw",
                "Install",
                "InstallInterrupt",
                "TrashInterrupt",
                "RunProgram"
            };

            while (true)
            {
                for (int i = 0; i < defaultActionNames.Count; i++)
                {
                    Console.WriteLine($"{i}. {defaultActionNames[i]}");
                }

                if (int.TryParse(Console.ReadLine(), out int index) is false)
                {
                    continue;
                }

                if (index >= sourcePlayer.DefaultActions.Count
                    || index < 0)
                {
                    continue;
                }

                sourcePlayer.DefaultActions[index].Invoke(match, sourcePlayer, this);
                return;
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
