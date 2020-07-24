using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuizEnamSesi.Repository;
using QuizEnamSesi.Model;

namespace QuizEnamSesi.Handler
{
    public class ViewProductHandler
    {
        public static List<Product> GetAllProductHandler()
        {
            return ProductRepository.GetAllProduct();
        }

        public static Boolean CheckReferencesHandler(int id)
        {
            return ProductRepository.CheckReferences(id);
        }

        public static void DeleteProductHandler(int id)
        {
            ProductRepository.DeleteProduct(id);
        }
    }
}