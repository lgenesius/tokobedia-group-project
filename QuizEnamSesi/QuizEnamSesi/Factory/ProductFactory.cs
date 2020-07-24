using QuizEnamSesi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuizEnamSesi.Factory
{
    public static class ProductFactory
    {
        public static Product CreateNewProduct(int typeId, string name, int stock, int price)
        {
            Product product = new Product();
            product.ProductTypeID = typeId;
            product.Name = name;
            product.Stock = stock;
            product.Price = price;
            return product;
        }
    }
}