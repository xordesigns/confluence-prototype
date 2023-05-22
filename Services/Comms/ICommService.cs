using ConfluencePrototype.Enums;
using ConfluencePrototype.Models;
using ConfluencePrototype.Models.Cards;
using ConfluencePrototype.Models.Players;

namespace ConfluencePrototype.Services.Comms
{
    public interface ICommService
    {
        public void PerformDefaultAction(Match match, Player sourcePlayer);
        public bool PlayLambdaFromHand(Player targetPlayer);
        public int GetCardIndexFromHand(Player targetPlayer, CardType? targetType = null);
        public Coords GetSlotCoordinates(Player targetPlayer);
        public Coords GetInterruptSlotCoordinates(Player targetPlayer);
        public int GetCardIndexFromList(List<Card> cardList);
        public int GetProgramIndex();
        public bool GetYouMayResult(string prompt);
    }
}
