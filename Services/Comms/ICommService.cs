using ConfluencePrototype.Models.Players;

namespace ConfluencePrototype.Services.Comms
{
    public interface ICommService
    {
        public bool PlayLambdaFromHand(Player targetPlayer);
        public int GetLambdaIndexFromHand(Player targetPlayer);
    }
}
