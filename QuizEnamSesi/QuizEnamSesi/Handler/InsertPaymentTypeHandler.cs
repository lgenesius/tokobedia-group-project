using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuizEnamSesi.Repository;

namespace QuizEnamSesi.Handler
{
    public class InsertPaymentTypeHandler
    {
        public static void InsertNewPaymentTypeHandler(string name)
        {
            PaymentTypeRepository.InsertNewPaymentType(name);
        }

        public static int CheckPaymentTypeHandler(string name)
        {
            return PaymentTypeRepository.CheckPaymentType(name);
        }
    }
}