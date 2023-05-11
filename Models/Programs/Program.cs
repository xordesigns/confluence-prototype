using ConfluencePrototype.Models.Players;

namespace ConfluencePrototype.Models.Programs
{
    public class Program
    {
        public List<Slot> Slots;
        public Player Owner;

        public Program(int numberOfSlots, Player owner)
        {
            var slots = new List<Slot>();

            for (int i = 1; i <= numberOfSlots; i++)
            {
                slots.Add(new Slot
                (
                    coords: new Coords(numberOfSlots, i),
                    owner: owner
                ));
            }

            Slots = slots;
            Owner = owner;
        }
    }
}
