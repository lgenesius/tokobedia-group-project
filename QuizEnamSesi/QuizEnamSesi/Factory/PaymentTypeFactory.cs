using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuizEnamSesi.Model;

namespace QuizEnamSesi.Factory
{
    public static class PaymentTypeFactory
    {
        public static PaymentType CreateNewPaymentType(string name)
        {
            PaymentType payment = new PaymentType();
            payment.Type = name;
            return payment;
        }
    }
}