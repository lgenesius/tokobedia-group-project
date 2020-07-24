using QuizEnamSesi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuizEnamSesi.Factory
{
    public static class ProductTypeFactory
    {
        public static ProductType CreateNewProductType(string name, string desc)
        {
            ProductType product = new ProductType();
            product.Name = name;
            product.Description = desc;
            return product;
        }
    }
}