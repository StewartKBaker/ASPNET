using System.Collections.Generic;
using System.Data;
using Dapper;
using Testing.Models;

namespace Testing
{
    public class ProductRepo : IProductRepo
    {
        private readonly IDbConnection _connection;

        public ProductRepo(IDbConnection dbconnection)
        {
            _connection = dbconnection;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            var products = _connection.Query<Product>("SELECT * FROM PRODUCTS;");

            return products;
        }

        public Product GetProduct(int id)
        {
            
            var product = _connection.QuerySingle<Product>("SELECT * FROM PRODUCTS WHERE ProductID = @id", new { id = id });

            return product; 
        }
    }
}