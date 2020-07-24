using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuizEnamSesi.Handler;
using QuizEnamSesi.Model;

namespace QuizEnamSesi.Controller
{
    public class ViewProductController
    {
        public static List<Product> GetAllProductController()
        {
            return ViewProductHandler.GetAllProductHandler();
        }

        public static Boolean DeleteValidation(int productId, out string errorMessage)
        {
            errorMessage = "";
            Boolean isReference = ViewProductHandler.CheckReferencesHandler(productId);

            if (isReference == true)
            {
                ViewProductHandler.DeleteProductHandler(productId);
                return true;
                
            }
            else
            {
                errorMessage = "Cannot delete item that have another references";
                return false;
            }
        }
    }
}