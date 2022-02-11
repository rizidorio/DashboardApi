using System.Collections.Generic;

namespace Dashboard.Domain.Entity
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Value { get; private set; }


        public Product(string name, string description, decimal value)
        {
            Name = name;
            Description = description;
            Value = value;
        }

        public void Update(string name, string description, decimal value)
        {
            Name = name;
            Description = description;
            Value = value;
        }
    }
}
