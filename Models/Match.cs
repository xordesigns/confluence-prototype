using ConfluencePrototype.Data.Builders;
using ConfluencePrototype.Models.Players;
using ConfluencePrototype.Models.Programs;
using Prog = ConfluencePrototype.Models.Programs.Program;

namespace ConfluencePrototype.Models
{
    public class Match
    {
        public readonly Player[] Players;

        public Player Active;

        public Prog[] AllPrograms;

        public Prog PlayerOneP1 => this.AllPrograms[0];
        public Prog PlayerOneP2 => this.AllPrograms[1];
        public Prog PlayerOneP3 => this.AllPrograms[2];

        public Prog PlayerTwoP1 => this.AllPrograms[3];
        public Prog PlayerTwoP2 => this.AllPrograms[4];
        public Prog PlayerTwoP3 => this.AllPrograms[5];

        public int RoundNumber;

        public List<List<MatchEvent>> EventsPerRound;

        public Match(string playerOneName, List<string> playerOneDecklist, string playerTwoName, List<string> playerTwoDecklist)
        {
            this.Players = new Player[2]
            {
                new Player(0, playerOneName, new()),
                new Player(1, playerTwoName, new())
            };

            this.Players[0].Deck.Cards = CardMapping.GetCardsFromDecklist(this.Players[0], playerOneDecklist);
            this.Players[1].Deck.Cards = CardMapping.GetCardsFromDecklist(this.Players[1], playerTwoDecklist);

            this.Active = this.Players[0];

            this.AllPrograms = new Prog[6];

            for (int i = 0; i < this.AllPrograms.Length; i++)
            {
                this.AllPrograms[i] = new Prog(
                    numberOfSlots: (i % 3) + 1, 
                    owner: i > 2 ? this.Players[1] : this.Players[0]);
            }

            this.RoundNumber = 1;

            this.EventsPerRound = new()
            {
                new()
            };
        }

        public void HandleEvent(MatchEvent newEvent)
        {
            this.EventsPerRound[this.RoundNumber - 1].Add(newEvent);
            Console.WriteLine(newEvent.Message);
        }

        public Prog GetProgramFromNumber(Player owner, int programNumber)
        {
            return this.AllPrograms[(owner.Id * 2) + (programNumber - 1)];
        }

        public Slot GetSlotFromCoords(Coords coords)
        {
            var owner = this.Players[coords.PlayerId];
            return this.GetProgramFromNumber(owner, coords.Program).Slots[coords.Slot - 1];
        }
    }
}
