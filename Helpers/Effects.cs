using ConfluencePrototype.Enums;
using ConfluencePrototype.Models;
using ConfluencePrototype.Models.Cards;
using ConfluencePrototype.Models.Events;
using ConfluencePrototype.Models.Players;
using ConfluencePrototype.Models.Programs;
using ConfluencePrototype.Services.Comms;

namespace ConfluencePrototype.Helpers
{
    public static class Effects
    {
        public static void Draw(Match match, Card targetCard, Player sourcePlayer, IZone sourceZone)
        {
            MoveCardToZone(match, sourcePlayer, sourceZone, sourcePlayer.Hand, targetCard);

            var drawEvent = new MatchEvent
            (
                type: ActionType.Draw,
                source: sourcePlayer,
                data: new DrawEventData(targetCard),
                message: $"Player {sourcePlayer.Name} drew {targetCard.Name} from {sourceZone.Type}"
            );

            match.HandleEvent(drawEvent);
        }

        private static void MoveCardToZone(Match match, Player sourcePlayer, IZone source, IZone destination, Card card)
        {
            if (source.Remove(card))
            {
                destination.Add(card);
            }

            var moveEvent = new MatchEvent
            (
                type: ActionType.Move,
                source: sourcePlayer,
                data: new MoveEventData(source: source, destination: destination, card: card),
                message: $"Player {sourcePlayer.Name} moved {card.Name} from {source.Type} to {destination.Type}"
            );

            match.HandleEvent(moveEvent);
        }

        public static void Trash(Match match, Player sourcePlayer, IZone sourceZone, Card targetCard)
        {
            MoveCardToZone(match, sourcePlayer, sourceZone, sourcePlayer.Trash, targetCard);

            var trashEvent = new MatchEvent
            (
                type: ActionType.Trash,
                source: sourcePlayer,
                data: new TrashEventData(sourceZone: sourceZone, card: targetCard),
                message: $"Player {sourcePlayer.Name} trashed {targetCard.Name} from {sourceZone.Type}"
            );

            match.HandleEvent(trashEvent);
        }

        public static void Install(Match match, Card targetCard, IZone sourceZone, Player sourcePlayer, Slot targetSlot)
        {
            if (targetSlot.Owner != sourcePlayer)
            {
                return;
            }

            if (targetSlot.InstalledCard is not null)
            {
                Trash(match, sourcePlayer, targetSlot, targetSlot.InstalledCard);
            }

            MoveCardToZone(match, sourcePlayer, sourceZone, targetSlot, targetCard);

            var installEvent = new MatchEvent
            (
                type: ActionType.Install,
                source: sourcePlayer,
                data: new InstallEventData(targetCard, targetSlot),
                message: $"Player {sourcePlayer.Name} installed {targetCard.Name} in P{targetSlot.Coords.Program}/{targetSlot.Coords.Slot}"
            );

            match.HandleEvent(installEvent);
        }

        public static void InstallInterrupt(Match match, Card targetCard, IZone sourceZone, Player sourcePlayer, Slot targetSlot)
        {
            if (targetSlot.Owner == sourcePlayer)
            {
                return;
            }

            if (targetSlot.Interrupt is not null)
            {
                Trash(match, sourcePlayer, targetSlot, targetSlot.Interrupt);
            }

            MoveCardToZone(match, sourcePlayer, sourceZone, targetSlot, targetCard);

            var installEvent = new MatchEvent
            (
                type: ActionType.InstallInterrupt,
                source: sourcePlayer,
                data: new InstallEventData(targetCard, targetSlot),
                message: $"Player {sourcePlayer.Name} installed {targetCard.Name} as an interrupt in P{targetSlot.Coords.Program}/{targetSlot.Coords.Slot}"
            );

            match.HandleEvent(installEvent);
        }

        public static void Execute(Match match, ICommService commService, Card? targetCard, Player sourcePlayer, Coords slotCoords)
        {
            if (targetCard is null)
            {
                return;
            }

            targetCard.Effect.Execute(match, sourcePlayer, commService, slotCoords.Slot);

            var executeEvent = new MatchEvent
            (
                type: ActionType.Execute,
                source: sourcePlayer,
                data: new ExecuteEventData(targetCard, slotCoords),
                message: $"Player {sourcePlayer.Name} executed {targetCard}@{slotCoords.Slot}"
            );

            match.HandleEvent(executeEvent);
        }
    }
}
