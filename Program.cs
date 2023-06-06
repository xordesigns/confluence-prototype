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

            var testDecklist = new List<string>
            {
                "Obelisk",
                "Struct",
                "Fetch",
                "Alloc8",
                "Darknes",
                "Killr",
                "Memfree",
                "MemSpike",
                "Reflection"
            };

            for (int i = 0; i < 5; i++)
            {
                testDecklist.AddRange(testDecklist);
            }

            Match match = new ("Dacko", testDecklist, "Damjan", testDecklist, commService);

            match.RunMatch();

            //DefaultActions.Draw(match, match.Players[0], commService);
            //DefaultActions.Install(match, match.Players[0], commService);
            //DefaultActions.RunProgram(match, match.Players[0], commService);
        }
    }
}