using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuizEnamSesi.Handler;

namespace QuizEnamSesi.Controller
{
    public class InsertProductTypeController
    {
        public static void InsertNewProductTypeController(string name, string desc)
        {
            InsertProductTypeHandler.InsertNewProductTypeHandler(name, desc);
        }

        public static Boolean ProductTypeValidation(string name, string desc, out string errorMessage)
        {
            errorMessage = "";
            if (name == String.Empty || desc == String.Empty)
            {
                errorMessage = "No data can empty";
                return false;
            }
            else if (name.Length < 5)
            {
                errorMessage = "Name must be more than 5 characters";
                return false;
            }
            else if (InsertProductTypeHandler.CheckProductTypeHandler(name) > 0)
            {
                errorMessage = "Already have the product name";
                return false;
            }
            return true;
        }
    }
}