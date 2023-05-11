using ConfluencePrototype.Models.Players;
using Prog = ConfluencePrototype.Models.Programs.Program;

namespace ConfluencePrototype.Models
{
    public class Match
    {
        public readonly Player PlayerOne;
        public readonly Player PlayerTwo;

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

        public Match(Player playerOne, Player playerTwo)
        {
            this.PlayerOne = playerOne;
            this.PlayerTwo = playerTwo;

            this.Active = this.PlayerOne;

            this.AllPrograms = new Prog[6];

            for (int i = 0; i < this.AllPrograms.Length; i++)
            {
                this.AllPrograms[i] = new Prog((i % 3) + 1, i > 2 ? playerOne : playerTwo);
            }

            this.RoundNumber = 1;

            this.EventsPerRound = new();
            this.EventsPerRound.Add(new());
        }

        public void HandleEvent(MatchEvent newEvent)
        {
            this.EventsPerRound[this.RoundNumber].Add(newEvent);
            Console.WriteLine(newEvent.Message);
        }
    }
}
