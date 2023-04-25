using ConfluencePrototype.Models.Players;

namespace ConfluencePrototype.Models.Programs
{
    internal class Program
    {
        public List<Slot> Slots;
        public Player Owner;

        public Program(int numberOfSlots, Player owner)
        {
            var slots = new List<Slot>();

            for (int i = 1; i <= numberOfSlots; i++)
            {
                slots.Add(new Slot(new Coords(numberOfSlots, i)));
            }

            Slots = slots;
            Owner = owner;
        }
    }
}
