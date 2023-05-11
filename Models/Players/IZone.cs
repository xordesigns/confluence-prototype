using ConfluencePrototype.Enums;
using ConfluencePrototype.Models.Cards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfluencePrototype.Models.Players
{
    public interface IZone
    {
        public ZoneType Type { get; }

        public void Add(Card card);

        public bool Remove(Card card);
    }
}
