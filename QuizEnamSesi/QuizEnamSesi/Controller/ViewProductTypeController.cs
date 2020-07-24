using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuizEnamSesi.Handler;
using QuizEnamSesi.Model;

namespace QuizEnamSesi.Controller
{
    public class ViewProductTypeController
    {
        public static List<ProductType> GetAllProductTypeController()
        {
            return ViewProductTypeHandler.GetAllProductTypeHandler();
        }

        public static Boolean DeleteProductTypeController(int productTypeId, out string errorMessage)
        {
            errorMessage = "";
            if (ViewProductTypeHandler.CheckReferencesHandler(productTypeId) == false)
            {
                ViewProductTypeHandler.DeleteProductTypeHandler(productTypeId);
                return false;
            }
            else
            {
                errorMessage = "Product type has been used in another table";
                return true;
            }
        }
    }
}