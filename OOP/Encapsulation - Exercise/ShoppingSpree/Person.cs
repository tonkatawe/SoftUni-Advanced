namespace ShoppingSpree
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    public class Person
    {
        private string name;
        private decimal money;
        private List<Product> bag;

        public Person(string name, decimal money)
        {
            this.Name = name;
            this.Money = money;
            this.bag = new List<Product>();
        }
        public string Name
        {
            get { return this.name; }
            private set
            {
                if (value == string.Empty)
                {
                    throw new ArgumentException();
                }
                this.name = value;

            }
        }

        public decimal Money
        {
            get { return this.money; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }
                this.money = value;
            }
        }

        public void BuyProduct(Product product)
        {
            if (product.Cost <= this.Money)
            {
                this.bag.Add(product);
                this.money -= product.Cost;
                Console.WriteLine($"{this.Name} bought {product.Name}");

            }
            else
            {
                Console.WriteLine($"{this.Name} can't afford {product.Name}");
            }

        }

        public override string ToString()
        {

            if (this.bag.Count == 0)
            {
                return $"{this.Name} - Nothing bought";
            }
            else
            {

                return $"{this.Name} - {string.Join(", ", this.bag)}";
            }
        }
    }
}