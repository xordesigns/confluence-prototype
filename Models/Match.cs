using ConfluencePrototype.Models.Players;
using Prog = ConfluencePrototype.Models.Programs.Program;

namespace ConfluencePrototype.Models
{
    internal class Match
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
        }

        public void HandleEvent(string message)
        {
            // TODO placeholder implementation
            Console.WriteLine(message);
        }
    }
}
