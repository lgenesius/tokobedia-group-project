using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuizEnamSesi.Repository;
using QuizEnamSesi.Model;

namespace QuizEnamSesi.Handler
{
    public class HomeHandler
    {
        public static List<Product> GetFiveRandomProductHandler()
        {
            return ProductRepository.GetFiveRandomProduct();
        }

        public static Product GetProductHandler(int id)
        {
            return ProductRepository.GetProduct(id);
        }

        public static ProductType GetProductTypeHandler(int id)
        {
            return ProductTypeRepository.GetProductType(id);
        }

        public static Product checkProductId(int id)
        {
            return ProductRepository.checkProductId(id);
        }
    }
}