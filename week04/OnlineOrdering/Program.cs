using System;

namespace OnlineOrdering
{
    class Program
    {
        static void Main(string[] args)
        {
            Address a1 = new Address("123 Main St", "Miami", "FL", "USA");
            Customer c1 = new Customer("Patricia Harris", a1);
            Order o1 = new Order(c1);

            o1.AddProduct(new Product("Shoes", "SH001", 50, 2));
            o1.AddProduct(new Product("Hat", "HT003", 20, 1));

            Address a2 = new Address("Calle Falsa 123", "Santiago", "RM", "Chile");
            Customer c2 = new Customer("Fernanda Soto", a2);
            Order o2 = new Order(c2);

            o2.AddProduct(new Product("Notebook", "NB990", 1000, 1));
            o2.AddProduct(new Product("Mouse", "MS244", 25, 2));

            
            Console.WriteLine(o1.GetPackingLabel());
            Console.WriteLine(o1.GetShippingLabel());
            Console.WriteLine("Total: $" + o1.GetTotalCost());
            Console.WriteLine();

            Console.WriteLine(o2.GetPackingLabel());
            Console.WriteLine(o2.GetShippingLabel());
            Console.WriteLine("Total: $" + o2.GetTotalCost());
        }
    }
}
