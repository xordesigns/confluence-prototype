using ConfluencePrototype.Models.Cards;
using static ConfluencePrototype.Helpers.DefaultActions;

namespace ConfluencePrototype.Models.Players
{
    public class Player
    {
        public readonly int Id;
        public readonly string Name;

        public int Memory;

        public readonly Hand Hand;
        public Deck Deck;
        public readonly Trash Trash;

        public readonly List<DefaultAction> DefaultActions;

        public Player(int id, string name, List<Card> deck)
        {
            this.Id = id;
            this.Name = name;

            this.Memory = 5;

            this.Hand = new();
            this.Deck = new(deck);
            this.Trash = new();

            this.DefaultActions = new()
            {
                Draw,
                Install,
                InstallInterrupt,
                TrashInterrupt,
                RunProgram
            };
        }

        public void ChangeMemory(int amount)
        {
            this.Memory = Math.Clamp((this.Memory + amount), 0, 5);
        }
    }
}
