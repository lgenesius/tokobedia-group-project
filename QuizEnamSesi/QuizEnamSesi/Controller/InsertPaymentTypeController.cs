using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuizEnamSesi.Handler;

namespace QuizEnamSesi.Controller
{
    public class InsertPaymentTypeController
    {
        public static void InsertNewPaymentTypeController(string name)
        {
            InsertPaymentTypeHandler.InsertNewPaymentTypeHandler(name);
        }

        public static Boolean PaymentTypeValidation(string name, out string errorMessage)
        {
            errorMessage = "";
            if (name == String.Empty)
            {
                errorMessage = "No data can be empty";
                return false;
            }
            else if (name.Length < 3)
            {
                errorMessage = "Name must be more than 3 character";
                return false;
            }
            else if (InsertPaymentTypeHandler.CheckPaymentTypeHandler(name) > 0)
            {
                errorMessage = "Already have that payment type";
                return false;
            }
            return true;
        }
    }
}