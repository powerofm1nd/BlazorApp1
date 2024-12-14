using BlazorApp1.Models;

namespace BlazorApp1.Services
{
    public class ProductStorage
    {
        List<Product> products { get; set; }

        public void AddProduct(Product product)
        {
            products.Add(product);
        }

        public void RemoveProductByName(string name)
        {
            products.RemoveAll(p => p.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }

        public List<Product> GetProducts()
        {
            return new List<Product>(products);
        }

        public Product TakeProductByName(string name)
        {
            var foundProduct = products.Find(p => p.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

            if (foundProduct == null)
            {
                return null;
            }

            if (foundProduct.Quantity > 0)
            {
                foundProduct.Quantity -= 1;

                return new Product
                {
                    Name = foundProduct.Name,
                    Quantity = 1,
                    Price = foundProduct.Price
                };
            }

            return null; 
        }

        public void PutOneProduct(Product product) 
        {
            var foundProduct = products.Find(p => p.Name.Equals(product.Name, StringComparison.OrdinalIgnoreCase));

            if (foundProduct == null)
            {
                products.Add(product);
            }
            else
            {
                foundProduct.Quantity += 1;
            }
        }

        public ProductStorage()
        { 
            products = new List<Product>();

            products.Add(new Product 
            { 
                Name = "Limon",
                Quantity = 5,
                Price = 10,
            });

            products.Add(new Product
            {
                Name = "Grape",
                Quantity = 7,
                Price = 14,
            });
        }
    }
}