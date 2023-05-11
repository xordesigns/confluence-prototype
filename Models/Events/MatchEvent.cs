using ConfluencePrototype.Enums;
using ConfluencePrototype.Models.Players;

namespace ConfluencePrototype.Models
{
    public class MatchEvent
    {
        public readonly ActionType Type;
        public readonly Player Source;

        public readonly EventData Data;

        public readonly string Message;

        public MatchEvent(ActionType type, Player source, EventData data, string message)
        {
            this.Type = type;
            this.Source = source;
            this.Data = data;
            this.Message = message;
        }
    }
}
