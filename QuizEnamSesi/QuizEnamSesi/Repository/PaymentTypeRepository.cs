using QuizEnamSesi.Factory;
using QuizEnamSesi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuizEnamSesi.Repository
{
    public static class PaymentTypeRepository
    {
        static tokobediaModelContainer db = new tokobediaModelContainer();
        public static List<PaymentType> getPaymentTypes()
        {
            return db.PaymentTypes.ToList();
        }

        public static PaymentType GetPaymentType(int id)
        {
            return (from type in db.PaymentTypes
                    where type.ID == id
                    select type).FirstOrDefault();
        }

        public static void DeletePayment(int id)
        {
            PaymentType types = db.PaymentTypes.Where(a => a.ID == id).FirstOrDefault();
            db.PaymentTypes.Remove(types);
            db.SaveChanges();
        }

        public static Boolean CheckPaymentReferences(int id)
        {
            int isReferenced = (from HeaderTransaction in db.HeaderTransactions
                                where HeaderTransaction.PaymentTypeID == id
                                select HeaderTransaction).Count();

            if (isReferenced > 0) return true;
            return false;
        }

        public static int CheckPaymentType(string name)
        {
            int count = (from type in db.PaymentTypes
                         where type.Type.ToLower().Equals(name.ToLower())
                         select type).Count();

            return count;
        }

        public static void UpdatePaymentType(int id, string name)
        {
            PaymentType toUpdate = GetPaymentType(id);
            toUpdate.Type = name;
            db.SaveChanges();
        }

        public static void InsertNewPaymentType(string name)
        {
            PaymentType newProduct = PaymentTypeFactory.CreateNewPaymentType(name);
            db.PaymentTypes.Add(newProduct);
            db.SaveChanges();
        }
    }
}