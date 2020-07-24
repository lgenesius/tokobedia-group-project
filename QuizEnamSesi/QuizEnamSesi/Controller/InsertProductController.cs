using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuizEnamSesi.Handler;
using QuizEnamSesi.Model;

namespace QuizEnamSesi.Controller
{
    public class InsertProductController
    {
        public static List<ProductType> GetAllProductTypeController()
        {
            return InsertProductHandler.GetAllProductTypeHandler();
        }

        public static void InsertNewProductController(string name, int productType, int stock, int price)
        {
            InsertProductHandler.InsertNewProductHandler(name, productType, stock, price);
        }

        public static Boolean ProductValidation(string name, string stock, string price, string typeId, out string errorMessage)
        {
            errorMessage = "";
            if (name == String.Empty || price == String.Empty || typeId == string.Empty || stock == string.Empty)
            {
                errorMessage = "All fields must be filled in";
                return false;
            }
            else if (Int32.Parse(stock) < 1)
            {
                errorMessage = "Stock must be more than 1";
                return false;
            }
            else if (Int32.Parse(price) < 1000 || Int32.Parse(price) % 1000 != 0)
            {
                errorMessage = "Price must be more than 1000 and multiple of 1000";
                return false;
            }
            else if (InsertProductHandler.CheckProductTypeHandler(Int32.Parse(typeId)) == false)
            {
                errorMessage = "Product type not found";
                return false;
            }
            return true;
        }
    }
}