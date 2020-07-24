using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuizEnamSesi.Handler;
using QuizEnamSesi.Model;
using System.Text.RegularExpressions;

namespace QuizEnamSesi.Controller
{
    public class HomeController
    {
        public static List<Product> GetFiveRandomProductController()
        {
            return HomeHandler.GetFiveRandomProductHandler();
        }

        public static Product GetProductController(int id)
        {
            return HomeHandler.GetProductHandler(id);
        }

        public static ProductType GetProductTypeController(int id)
        {
            return HomeHandler.GetProductTypeHandler(id);  
        }

        public static Product checkProductId(int id)
        {
            return HomeHandler.checkProductId(id);
        }
    }
}