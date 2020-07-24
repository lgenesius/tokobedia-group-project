using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuizEnamSesi.Repository;
using QuizEnamSesi.Model;

namespace QuizEnamSesi.Handler
{
    public class InsertProductHandler
    {
        public static List<ProductType> GetAllProductTypeHandler()
        {
            return ProductTypeRepository.GetAllProductType();
        }

        public static void InsertNewProductHandler(string name, int productType, int stock, int price)
        {
           ProductRepository.InsertNewProduct(name, productType, stock, price);
        }

        public static Boolean CheckProductTypeHandler(int id)
        {
            return ProductTypeRepository.CheckProductType(id);
        }
    }
}