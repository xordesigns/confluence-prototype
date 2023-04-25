using ConfluencePrototype.Enums;
using ConfluencePrototype.Models.Players;

namespace ConfluencePrototype.Models
{
    internal class MatchEvent
    {
        public readonly ActionType Type;
        public readonly Player Source;

        public readonly EventData Data;

        public MatchEvent(ActionType type, Player source, EventData data)
        {
            this.Type = type;
            this.Source = source;
            this.Data = data;
        }
    }
}
