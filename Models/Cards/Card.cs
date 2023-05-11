using ConfluencePrototype.Enums;
using ConfluencePrototype.Models.Players;

namespace ConfluencePrototype.Models.Cards
{
    public abstract class Card
    {
        public readonly string Name;
        public readonly CardType Type;
        public readonly CardEffect Effect;
        public readonly Player Owner;

        public Card(string name, CardType type, CardEffect effect, Player owner)
        {
            this.Name = name;
            this.Type = type;
            this.Effect = effect;
            this.Owner = owner;
        }
    }
}
