using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuizEnamSesi.Repository;
using QuizEnamSesi.Model;

namespace QuizEnamSesi.Handler
{
    public class UpdateProductHandler
    {
        public static Product GetProductHandler(int id)
        {
            return ProductRepository.GetProduct(id);
        }

        public static void GetUpdateProductHandler(string name, int stock, int price, int id)
        {
            ProductRepository.UpdateProduct(name, stock, price, id);
        }
    }
}