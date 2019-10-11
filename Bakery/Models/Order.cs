using System.Collections.Generic;

namespace Bakery.Models
{
    public class Order
    {
        public string Name {get; set;}
        public string Description {get; set;}
        public int Price {get; set;}
        public string Date {get; set;}

        private static List<Order> _instances = new List<Order> {};

        public Order (string name,string description, int price, string date)
        {
            Name = name;
            Description = description;
            Price = price;
            Date = date;
            _instances.Add(this);
        }

        public static List<Order> GetAll()
        {
        return _instances;
        }

        public static void ClearAll()
        {
        _instances.Clear();
        }
    }
}




    }
}