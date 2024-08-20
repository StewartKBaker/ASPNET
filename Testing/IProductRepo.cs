using System;
using System.Collections.Generic;
using Testing.Models;

namespace Testing
{
    public interface IProductRepo
    {
        IEnumerable<Product> GetAllProducts();
    }
}