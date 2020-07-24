using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuizEnamSesi.Model;
using QuizEnamSesi.Factory;

namespace QuizEnamSesi.Repository
{
    public class TransactionReportRepository
    {
        private static tokobediaModelContainer db = DatabaseSingleton.GetInstance();

        public static List<HeaderTransaction> GetTransactions()
        {
            return db.HeaderTransactions.ToList();
        }

        public static List<TransactionReportModel> GetAllReport()
        {
            tokobediaModelContainer dbs = new tokobediaModelContainer();
            List<TransactionReportModel> allData = new List<TransactionReportModel>();
            var result = (from x in dbs.HeaderTransactions
                          join y in dbs.DetailTransactions on x.ID equals y.TransactionID
                          join z in dbs.PaymentTypes on x.PaymentTypeID equals z.ID
                          join w in dbs.Products on y.ProductID equals w.ID
                          join v in dbs.Users on x.UserID equals v.Id
                          select new
                          {
                              TransID = x.ID,
                              UserName = v.Name,
                              Date = x.Date,
                              ProductName = w.Name,
                              Quantity = y.Quantity,
                              ProductPrice = w.Price
                          }).ToList();

            foreach (var xdata in result)
            {
                allData.Add(TransactionReportFactory.createTransRepObject(xdata));
            }

            return allData;
        }
    }
}