using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuizEnamSesi.Repository;
using QuizEnamSesi.Model;

namespace QuizEnamSesi.Handler
{
    public class ViewPaymentTypeHandler
    {
        public static List<PaymentType> getAllPaymentTypes()
        {
            return PaymentTypeRepository.getPaymentTypes();
        }

        public static Boolean CheckPaymentReferencesHandler(int id)
        {
            return PaymentTypeRepository.CheckPaymentReferences(id);
        }

        public static void DeletePaymentTypeHandler(int id)
        {
            PaymentTypeRepository.DeletePayment(id);
        }
    }
}