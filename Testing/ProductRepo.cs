using System.Collections.Generic;
using System.Data;
using Dapper;
using Microsoft.AspNetCore.Mvc;
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

        public void UpdateProduct(Product product)
        {
            _connection.Execute("UPDATE products SET Name = @name, Price = @price WHERE ProductID = @id",
                new { name = product.Name, price = product.Price, id = product.ProductID });
        }

        public void InsertProduct(Product productToInsert)
        {
            _connection.Execute("INSERT INTO product (NAME, PRICE, CATEGORYID) VALUES (@name, @price, @categoryID);",
                new
                {
                    name = productToInsert.Name, price = productToInsert.Price, categoryID = productToInsert.CategoryID
                });
        }

        public IEnumerable<Category> GetCategories()
        {
            return _connection.Query<Category>("SELECT * FROM categories;");
        }

        public Product AssignCategory()
        {
            var categoryList = GetCategories();
            var product = new Product();
            product.Categories = categoryList;
            return product;
        }
    }
}