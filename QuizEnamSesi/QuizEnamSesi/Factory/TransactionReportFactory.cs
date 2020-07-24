using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuizEnamSesi.Model;

namespace QuizEnamSesi.Factory
{
    public class TransactionReportFactory
    {
        public static TransactionReportModel createTransRepObject(dynamic xdata)
        {
            TransactionReportModel tempData = new TransactionReportModel();
            tempData.transId = xdata.TransID;
            tempData.userName = xdata.UserName;
            tempData.transDate = xdata.Date;
            tempData.productName = xdata.ProductName;
            tempData.quantity = xdata.Quantity;
            tempData.subTotal = xdata.ProductPrice * xdata.Quantity;
            return tempData;
        }
    }
}