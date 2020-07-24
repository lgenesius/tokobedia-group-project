using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuizEnamSesi.Handler;
using QuizEnamSesi.Model;

namespace QuizEnamSesi.Controller
{
    public class UpdateProductController
    {
        public static Product GetProductController(int id)
        {
            return UpdateProductHandler.GetProductHandler(id);
        }

        public static void GetUpdateProductController(string name, int stock, int price, int id)
        {
            UpdateProductHandler.GetUpdateProductHandler(name, stock, price, id);
        }

        public static Boolean UpdateProductValidation(string name, string stock, string price, out string errorMessage)
        {
            errorMessage = "";
            if (name == String.Empty || stock == String.Empty || price == String.Empty)
            {
                errorMessage = "No data can empty";
                return false;
            }
            else if (stock.All(Char.IsLetter) || price.All(Char.IsLetter))
            {
                errorMessage = "Stock and Price must be integer";
                return false;
            }
            else if (Int32.Parse(stock) < 1)
            {
                errorMessage = "Stock must more than 1";
                return false;
            }
            else if (Int32.Parse(price) < 1000 || Int32.Parse(price) % 1000 != 0)
            {
                errorMessage = "Price must be more than 1000 and multiple of 1000";
                return false;
            }
            return true;
        }
    }
}