using System.Collections.Generic;

namespace Bakery.Models
{
    public class Vendor
    {
        private static List<Vendor> _instances = new List<Vendor> {};

        public string Name { get; set; }

        public string Description { get; set; }
        public int Id { get; }
        public List<Order> Orders { get; set; } 

        public Vendor (string vendorName)
        {
            Name = vendorName;
            Orders = new List<Order>{};
            _instances.Add(this);
            Id = _instances.Count;
        }

        public static void ClearAll()
        {
        _instances.Clear();
        }

         public static List<Vendor> GetAll()
        {
        return _instances;
        }

        public void AddOrder(Order order)
        {
        Orders.Add(order);
        }

        public static Vendor Find(int searchId)
        {
        return _instances[searchId - 1];
        }

        }

}

        

