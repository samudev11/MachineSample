using System;
using System.Collections.Generic;
using System.Linq;

namespace VendingMachine.Domain
{
    //Aggregate root
    public class Machine
    {
        private List<Piles> piles = new List<Piles>();

        public Machine(string identifier)
        {
            this.Identifier = identifier ?? throw new ArgumentNullException(nameof(identifier));
        }

        public Guid Id { get; protected set; }

        public string Identifier { get; }

        public IReadOnlyList<Piles> Piles => this.piles ??= new List<Piles>();

        public void AddPile(int count, int capacity)
        {
            if (count <= 0 || count > 6) throw new ArgumentOutOfRangeException(nameof(count));
            if (capacity <= 0) throw new ArgumentOutOfRangeException(nameof(capacity));

            for (var i = 1; i <= count; i++)
            {
                this.piles.Add(new Piles(i, capacity));
            }
        }

        public void AddSnackToPile(Snack snack, int pileNumber)
        {
            if (snack == null) throw new ArgumentNullException(nameof(snack));
            if (pileNumber <= 0) throw new ArgumentOutOfRangeException(nameof(pileNumber));

            if (this.piles.All(x => x.Number != pileNumber))
            {
                throw new InvalidOperationException("There is no pile with this number");
            }

            this.piles[pileNumber].AddSnack(snack);
        }
    }
}
