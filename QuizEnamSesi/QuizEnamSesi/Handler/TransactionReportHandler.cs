using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuizEnamSesi.Model;
using QuizEnamSesi.Repository;

namespace QuizEnamSesi.Handler
{
    public class TransactionReportHandler
    {
        public static List<HeaderTransaction> GetTransactions()
        {
            return TransactionReportRepository.GetTransactions();
        }

        public static List<TransactionReportModel> getAllReportData()
        {
            return TransactionReportRepository.GetAllReport();
        }
    }
}