using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuizEnamSesi.Repository;
using QuizEnamSesi.Model;

namespace QuizEnamSesi.Handler
{
    public class UpdatePaymentTypeHandler
    {
        public static PaymentType GetPaymentTypeHandler(int id)
        {
            return PaymentTypeRepository.GetPaymentType(id);
        }

        public static void GetUpdatePaymentTypeHandler(int id, string name)
        {
            PaymentTypeRepository.UpdatePaymentType(id, name);
        }

        public static int CheckPaymentTypeHandler(string name)
        {
            return PaymentTypeRepository.CheckPaymentType(name);
        }
    }
}