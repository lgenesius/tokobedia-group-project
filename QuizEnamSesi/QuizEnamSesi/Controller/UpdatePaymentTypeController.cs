using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuizEnamSesi.Handler;
using QuizEnamSesi.Model;

namespace QuizEnamSesi.Controller
{
    public class UpdatePaymentTypeController
    {
        public static PaymentType GetPaymentTypeController(int id)
        {
            return UpdatePaymentTypeHandler.GetPaymentTypeHandler(id);
        }

        public static void GetUpdatePaymentTypeController(int id, string name)
        {
            UpdatePaymentTypeHandler.GetUpdatePaymentTypeHandler(id, name);
        }

        public static Boolean PaymentTypeValidation(string name, string oldTypeName, out string errorMessage)
        {
            errorMessage = "";
            if (name == String.Empty)
            {
                errorMessage = "No data can empty";
                return false;
            }
            else if (name.Length < 3)
            {
                errorMessage = "Name must be more than 3 characters";
                return false;
            }
            else if (name.Equals(oldTypeName))
            {
                return true;
            }
            else if (UpdatePaymentTypeHandler.CheckPaymentTypeHandler(name) > 0)
            {
                errorMessage = "Already have the payment type";
                return false;
            }
            return true;
        }
    }
}