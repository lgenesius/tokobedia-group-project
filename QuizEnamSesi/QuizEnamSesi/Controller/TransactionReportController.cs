using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuizEnamSesi.Helper;
using QuizEnamSesi.Model;
using QuizEnamSesi.Handler;

namespace QuizEnamSesi.Controller
{
    public class TransactionReportController
    {
        public static List<HeaderTransaction> GetTransaction()
        {
            return JsonHelper.Deserialize<List<HeaderTransaction>>(GetTransactions1());
        }

        public static string GetTransactions1()
        {
            return JsonHelper.Serialize(TransactionReportHandler.GetTransactions());
        }

        public static List<TransactionReportModel> getAllReportData()
        {
            return TransactionReportHandler.getAllReportData();
        }
    }
}