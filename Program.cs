using ConfluencePrototype.Helpers;
using ConfluencePrototype.Models;
using ConfluencePrototype.Services.Comms;

namespace ConfluencePrototype
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var commService = new ConsoleCommService();

            var testDecklist = new List<string>();

            Random rand = new();

            for (int i = 0; i < 20; i++)
            {
                if (rand.Next(2) > 0)
                {
                    testDecklist.Add("Obelisk");
                }
                else
                {
                    testDecklist.Add("Fetch");
                }
            }

            Match match = new ("Dacko", testDecklist, "Damjan", testDecklist);

            DefaultActions.Draw(match, match.Players[0], commService);
            DefaultActions.Install(match, match.Players[0], commService);
            DefaultActions.RunProgram(match, match.Players[0], commService);
        }
    }
}