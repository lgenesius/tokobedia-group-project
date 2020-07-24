using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuizEnamSesi.Repository;
using QuizEnamSesi.Model;

namespace QuizEnamSesi.Handler
{
    public class TransactionHandler
    {
        public static List<TransactionModel> getHistoryData(int userId)
        {
            return TransactionRepository.GetHistory(userId);
        }

        public static List<TransactionModel> getAllHistoryData()
        {
            return TransactionRepository.GetAllHistory();
        }
    }
}