﻿using ConfluencePrototype.Enums;
using ConfluencePrototype.Helpers;
using ConfluencePrototype.Models.Cards;
using ConfluencePrototype.Models.Players;
using ConfluencePrototype.Services.Comms;

namespace ConfluencePrototype.Models.Programs
{
    public class Slot
        : IZone
    {
        public Coords Coords;
        private Card? Lambda;
        private Card? Function;
        public Function? Interrupt;
        public bool InterruptLocked;
        public readonly Player Owner;

        public Card? InstalledCard => this.Lambda ?? this.Function;

        public ZoneType Type => ZoneType.Slot;

        public Slot(Coords coords, Player owner)
        {
            this.Coords = coords;
            this.Lambda = null;
            this.Function = null;
            this.Interrupt = null;
            this.InterruptLocked = true;
            this.Owner = owner;
        }

        public void Execute(Match match, ICommService commService)
        {
            bool playLambdaFromHand = commService.PlayLambdaFromHand(this.Owner);

            if (playLambdaFromHand)
            {
                var selectedLambdaIndex = commService.GetCardIndexFromHand(this.Owner, CardType.Lambda);

                var targetLambda = this.Owner.Hand.Cards[selectedLambdaIndex];

                Effects.Trash(match, this.Owner, this, targetLambda);

                Effects.Execute(match, commService, targetLambda, this.Owner, this.Coords);

                this.ExecuteInterrupt(match, commService);
            }
            else
            {
                this.ExecuteInstalled(match, commService);
            }
        }

        private void ExecuteInstalled(Match match, ICommService commService)
        {
            if (this.InstalledCard?.Type == CardType.Lambda)
            {
                Effects.Execute(match, commService, this.InstalledCard, this.Owner, this.Coords);
                this.ExecuteInterrupt(match, commService);
            }
            else
            {
                this.ExecuteInterrupt(match, commService);

                if (this.InterruptLocked) { return; }

                Effects.Execute(match, commService, this.InstalledCard, this.Owner, this.Coords);
            }
        }

        private void ExecuteInterrupt(Match match, ICommService commService)
        {
            Effects.Execute(match, commService, this.Interrupt, match.GetOpponentForPlayer(this.Owner), this.Coords);
            this.InterruptLocked = false;
        }

        public void Add(Card card)
        {
            if (card is Function func)
            {
                if (func.Owner != this.Owner)
                {
                    this.Interrupt = func;
                }
                else
                {
                    this.Function = func;
                }
            }
            else
            {
                this.Lambda = card;
            }
        }

        public bool Remove(Card card)
        {
            if (card.Owner != this.Owner)
            {
                this.Interrupt = null;
                this.InterruptLocked = false;
            }
            else
            {
                if (card.Type == CardType.Function)
                {
                    this.Function = null;
                }
                else
                {
                    this.Lambda = null;
                }
            }

            return true;
        }
    }
}
