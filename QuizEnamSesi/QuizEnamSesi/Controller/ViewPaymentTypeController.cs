using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuizEnamSesi.Handler;
using QuizEnamSesi.Model;

namespace QuizEnamSesi.Controller
{
    public class ViewPaymentTypeController
    {
        public static List<PaymentType> GetAllPaymentTypeController()
        {
            return ViewPaymentTypeHandler.getAllPaymentTypes();
        }

        public static Boolean DeletePaymentTypeController(int paymentTypeId, out string errorMessage)
        {
            errorMessage = "";
            if (ViewPaymentTypeHandler.CheckPaymentReferencesHandler(paymentTypeId) == false)
            {
                ViewPaymentTypeHandler.DeletePaymentTypeHandler(paymentTypeId);
                return false;
            }
            else
            {
                errorMessage = "Payment type has been used in another table";
                return true;
            }
        }
    }
}