using System;
using System.Collections.Generic;
using Testing.Models;

namespace Testing
{
    public interface IProductRepo
    {
        public IEnumerable<Product> GetAllProducts();
        
        public Product GetProduct(int id);
        
        void UpdateProduct(Product product);
    }
}