using ConfluencePrototype.Models.Players;

namespace ConfluencePrototype.Services.Comms
{
    internal interface ICommService
    {
        public bool PlayLambdaFromHand();
        public int GetLambdaIndexFromHand(Player targetPlayer);
    }
}
