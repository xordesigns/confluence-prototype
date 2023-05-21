using ConfluencePrototype.Enums;
using ConfluencePrototype.Models;
using ConfluencePrototype.Models.Players;

namespace ConfluencePrototype.Services.Comms
{
    public interface ICommService
    {
        public bool PlayLambdaFromHand(Player targetPlayer);
        public int GetCardIndexFromHand(Player targetPlayer, CardType? targetType = null);
        public Coords GetSlotCoordinates(Player targetPlayer);
    }
}
