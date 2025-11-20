using System.Collections.Generic;

namespace OnlineOrdering
{
    public class Order
    {
        private List<Product> _products = new List<Product>();
        private Customer _customer;

        public Order(Customer customer)
        {
            _customer = customer;
        }

        public void AddProduct(Product product)
        {
            _products.Add(product);
        }

        public double GetTotalCost()
        {
            double total = 0;

            foreach (Product p in _products)
            {
                total += p.GetTotalCost();
            }

            // Shipping cost rules
            if (_customer.LivesInUSA())
            {
                total += 5; // USA shipping
            }
            else
            {
                total += 35; // International shipping
            }

            return total;
        }

        public string GetPackingLabel()
        {
            string label = "PACKING LABEL:\n";

            foreach (Product p in _products)
            {
                label += $"{p.GetName()} (ID: {p.GetProductId()})\n";
            }

            return label;
        }

        public string GetShippingLabel()
        {
            return $"SHIPPING LABEL:\n{_customer.GetName()}\n{_customer.GetAddress().GetFullAddress()}";
        }
    }
}
