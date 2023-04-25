using ConfluencePrototype.Enums;
using ConfluencePrototype.Models.Cards;
using ConfluencePrototype.Models.Players;
using ConfluencePrototype.Services.Comms;

namespace ConfluencePrototype.Models.Programs
{
    internal class Slot
    {
        public Coords Coords;
        public Card? Lambda;
        public Card? Function;
        public Function? Interrupt;
        public bool IsInterruptLocked;
        public readonly Player Owner;

        public Card? InstalledCard => this.Lambda ?? this.Function;

        public Slot(Coords coords, Player owner)
        {
            this.Coords = coords;
            this.Lambda = null;
            this.Function = null;
            this.Interrupt = null;
            this.IsInterruptLocked = true;
            this.Owner = owner;
        }

        public bool Execute(ICommService commService)
        {
            var playLambdaFromHand = commService.PlayLambdaFromHand();

            if (playLambdaFromHand
                && commService.GetLambdaIndexFromHand(this.Owner) is not -1)
            {

            }
            else
            {
                this.ExecuteInstalled(commService);
            }
        }

        private void ExecuteInstalled(ICommService commService)
        {
            if (this.InstalledCard?.Type == CardType.Lambda)
            {
                this.InstalledCard.BaseEffect.ExecuteEffect(commService);
                this.InstalledCard.Effect?.ExecuteEffect(commService, this.Coords.Slot);
                this.Interrupt?.InterruptEffect.ExecuteEffect(commService);
            }
            else
            {
                this.Interrupt?.InterruptEffect.ExecuteEffect(commService);
                this.InstalledCard?.Effect?.ExecuteEffect(commService, this.Coords.Slot);
            }
        }
    }
}
