namespace ConfluencePrototype.Models
{
    public struct Coords
    {
        public readonly int PlayerId;
        public readonly int Program;
        public readonly int Slot;

        public Coords(int playerId, int program, int slot)
        {
            if (AreCoordsValid(program, slot))
            {
                this.PlayerId = playerId;
                this.Program = program;
                this.Slot = slot;
            }
            else
            {
                this.PlayerId = playerId;
                this.Program = 1;
                this.Slot = 1;
            }
        }

        public static bool AreCoordsValid(int program, int slot)
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

        public static bool AreInterruptCoordsValid(int program, int slot)
        {
            return program is not > 3 and not < 2
                && slot >= 2;
        }

        public override string ToString()
        {
            return $"[Player {this.PlayerId}]P{this.Program}/{this.Slot}";
        }

    }
}
