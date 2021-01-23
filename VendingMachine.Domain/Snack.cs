using System;

namespace VendingMachine.Domain
{
    public class Snack
    {
        public Snack(string name, decimal price)
        {
            this.Name = name ?? throw new ArgumentNullException(nameof(name));

            if (price <= 0) throw new ArgumentOutOfRangeException(nameof(price));
            this.Price = price;
        }

        public Guid Id { get; private set; }

        public string Name { get; private set; }

        public decimal Price { get; private set; }

        public void ChangeName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException(name);
            }

            this.Name = name;
        }

        public void UpdatePrice(decimal value)
        {
            if (value <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(value));
            }

            this.Price = value;
        }
    }
}