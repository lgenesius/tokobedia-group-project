using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuizEnamSesi.Factory;
using QuizEnamSesi.Model;

namespace QuizEnamSesi.Repository
{
    public class TransactionRepository
    {
        static tokobediaModelContainer db = new tokobediaModelContainer();
        public static HeaderTransaction InsertNewHeaderTrans(int userId, int paymentId, DateTime date)
        {
            HeaderTransaction headerTrans = TransactionFactory.CreateNewHeaderTrans(userId, paymentId, date);
            db.HeaderTransactions.Add(headerTrans);
            db.SaveChanges();
            return headerTrans;
        }

        public static void InsertNewDetailTrans(int transId, int productId, int quantity)
        {
            DetailTransaction detailTrans = TransactionFactory.CreateNewDetailTrans(transId, productId, quantity);
            db.DetailTransactions.Add(detailTrans);
            db.SaveChanges();
        }

        public static HeaderTransaction returnID(int userId)
        {
            return (from c in db.HeaderTransactions
                    join d in db.DetailTransactions on c.ID equals d.TransactionID
                    where c.UserID == userId && c.ID != d.TransactionID
                    select c).FirstOrDefault();
        }

       public static List<TransactionModel> GetHistory(int userId)
        {
            List<TransactionModel> allData = new List<TransactionModel>();
            var result = (from x in db.HeaderTransactions
                          join y in db.DetailTransactions on x.ID equals y.TransactionID
                          join z in db.PaymentTypes on x.PaymentTypeID equals z.ID
                          join w in db.Products on y.ProductID equals w.ID
                          where x.UserID == userId
                          select new
                          {
                              Date = x.Date,
                              PaymentTypeName = z.Type,
                              ProductName = w.Name,
                              Quantity = y.Quantity,
                              ProductPrice = w.Price
                          }).ToList();

            foreach(var xdata in result)
            {
                allData.Add(TransactionFactory.createTransObject(xdata));
            }

            return allData;
        }

        public static List<TransactionModel> GetAllHistory()
        {
            List<TransactionModel> allData = new List<TransactionModel>();
            var result = (from x in db.HeaderTransactions
                          join y in db.DetailTransactions on x.ID equals y.TransactionID
                          join z in db.PaymentTypes on x.PaymentTypeID equals z.ID
                          join w in db.Products on y.ProductID equals w.ID
                          select new
                          {
                              Date = x.Date,
                              PaymentTypeName = z.Type,
                              ProductName = w.Name,
                              Quantity = y.Quantity,
                              ProductPrice = w.Price
                          }).ToList();

            foreach (var xdata in result)
            {
                allData.Add(TransactionFactory.createTransObject(xdata));
            }

            return allData;
        }
    }
}