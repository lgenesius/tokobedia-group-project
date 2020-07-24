using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuizEnamSesi.Handler;
using QuizEnamSesi.Model;

namespace QuizEnamSesi.Controller
{
    public class UpdateProductTypeController
    {
        public static ProductType GetProductTypeController(int id)
        {
            return UpdateProductTypeHandler.GetProductTypeHandler(id);
        }

        public static void GetUpdateProductTypeController(int id, string name, string description)
        {
            UpdateProductTypeHandler.GetUpdateProductTypeHandler(id, name, description);
        }

        public static Boolean ProductTypeValidation(string name, string desc, string oldTypeName, out string errorMessage)
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
            else if (name.Equals(oldTypeName))
            {
                return true;
            }
            else if (UpdateProductTypeHandler.CheckProductTypeHandler(name) > 0)
            {
                errorMessage = "Already have that data";
                return false;
            }
            return true;
        }
    }
}