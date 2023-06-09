﻿using ConfluencePrototype.Enums;
using ConfluencePrototype.Models.Cards;
using ConfluencePrototype.Models.Players;

namespace ConfluencePrototype.Data.Builders
{
    public static class CardMapping
    {
        public static readonly Dictionary<string, (CardType type, CardEffect effect)> CardNameToCardEffect = new()
        {
            { "Obelisk", (CardType.Function, Effects.FunctionEffects.Obelisk) },
            { "Struct", (CardType.Function, Effects.FunctionEffects.Struct) },
            { "Alloc8", (CardType.Function, Effects.FunctionEffects.Alloc8) },
            { "Darknes", (CardType.Function, Effects.FunctionEffects.Darknes) },
            { "Killr", (CardType.Function, Effects.FunctionEffects.Killr) },
            { "Memfree", (CardType.Function, Effects.FunctionEffects.Memfree) },
            { "MemSpike", (CardType.Function, Effects.FunctionEffects.MemSpike) },
            { "Reflection", (CardType.Function, Effects.FunctionEffects.Reflection) },
            { "Fetch", (CardType.Lambda, Effects.LambdaEffects.Fetch) },
        };

        public static readonly Dictionary<string, CardEffect> FunctionNameToInterruptEffect = new()
        {
            { "Obelisk", Effects.InterruptEffects.Placeholder },
            { "Struct", Effects.InterruptEffects.Placeholder },
            { "Alloc8", Effects.InterruptEffects.Placeholder },
            { "Darknes", Effects.InterruptEffects.Placeholder },
            { "Killr", Effects.InterruptEffects.Placeholder },
            { "Memfree", Effects.InterruptEffects.Placeholder },
            { "MemSpike", Effects.InterruptEffects.Placeholder },
            { "Reflection", Effects.InterruptEffects.Placeholder },
        };

        public static List<Card> GetCardsFromDecklist(Player owner, List<string> decklist)
        {
            var cardList = new List<Card>();

            foreach (var cardName in decklist)
            {
                var (type, effect) = CardNameToCardEffect[cardName];
                if (type == CardType.Function)
                {
                    cardList.Add(new Function(cardName, effect, FunctionNameToInterruptEffect[cardName], owner));
                }
                else
                {
                    cardList.Add(new Lambda(cardName, effect, owner));
                }
            }

            return cardList;
        }
    }
}
