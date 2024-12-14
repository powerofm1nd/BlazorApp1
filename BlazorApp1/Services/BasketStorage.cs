using BlazorApp1.Models;
using System.Diagnostics;

namespace BlazorApp1.Services
{
    public class BasketStorage
    {
        List<Product> products;

        public BasketStorage()
        {
            products = new List<Product>();
        }

        public List<Product> GetProducts()
        {
            return products;
        }

        public decimal GetTotalPrice()
        {
            decimal totalPrice = 0;

            products.ForEach(product => 
            { 
                totalPrice += product.Price * product.Quantity;
            });

            return totalPrice;
        }

        public void AddProduct(Product product)
        {
            var foundProduct = products.Find(p => { return p.Name == product.Name; });

            if (foundProduct != null)
            {
                foundProduct.Quantity += 1;
            }
            else
            {
                products.Add(product);
            }
        }

        public void RemoveProduct(Product product)
        {
            var foundProduct = products.Find(p => p.Name.Equals(product.Name));

            if (foundProduct != null)
            {
                if (foundProduct.Quantity > 1)
                {
                    foundProduct.Quantity -= 1;
                }
                else
                {
                    products.Remove(foundProduct);
                }
            }
        }
    }
}