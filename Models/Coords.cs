namespace ConfluencePrototype.Models
{
    internal struct Coords
    {
        public int Program;
        public int Slot;

        public Coords(int program, int slot)
        {
            if (AreCoordsValid(program, slot))
            {
                this.Program = program;
                this.Slot = slot;
            }
            else
            {
                this.Program = 1;
                this.Slot = 1;
            }
        }

        private static bool AreCoordsValid(int program, int slot)
        {
            if (program is > 3 or < 1)
            {
                return false;
            }

            return program switch
            {
                1 when slot > 1 => false,
                2 when slot > 2 => false,
                3 when slot > 3 => false,
                _ => true,
            };
        }

        public override string ToString()
        {
            return $"P{this.Program}/{this.Slot}";
        }

    }
}
