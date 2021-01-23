using System;
using System.Collections.Generic;

namespace VendingMachine.Domain
{
    public class Piles
    {
        private List<Snack> snacks;

        public Piles(int number, int snackCapacity)
        {
            if (number <= 0 || number > 6)
            {
                throw new ArgumentOutOfRangeException(nameof(number));
            }

            if (snackCapacity <= 0 || snackCapacity > 11)
            {
                throw new ArgumentOutOfRangeException(nameof(snackCapacity));
            }

            this.Number = number;
            this.SnackCapacity = snackCapacity;
        }

        public Guid Id { get; protected set; }

        public int Number { get; private set; }

        public int SnackCapacity { get; private set; }

        public IReadOnlyList<Snack> Snacks => this.snacks ??= new List<Snack>(this.SnackCapacity);

        public void AddSnack(Snack snack)
        {
            if (snack == null) throw new ArgumentNullException(nameof(snack));

            if(this.snacks.Count == this.SnackCapacity)
            {
                throw new InvalidOperationException("The pile is full");
            }

            this.snacks.Add(snack);
        }
    }
}