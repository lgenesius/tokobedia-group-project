using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuizEnamSesi.Handler;
using QuizEnamSesi.Model;

namespace QuizEnamSesi.Controller
{
    public class TransactionController
    {
        public static List<TransactionModel> getHistoryData(int userId)
        {
            return TransactionHandler.getHistoryData(userId);
        }

        public static List<TransactionModel> getAllHistoryData()
        {
            return TransactionHandler.getAllHistoryData();
        }

        public static string getGrandTotal(List<TransactionModel> allCart)
        {
            int GrandTotal = 0;
            foreach(TransactionModel currHistory in allCart)
            {
                GrandTotal += (currHistory.subTotal);
            }

            return GrandTotal.ToString();
        }


    }

}