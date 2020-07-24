using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuizEnamSesi.Model;

namespace QuizEnamSesi.Factory
{
    public class TransactionFactory
    {
        public static HeaderTransaction CreateNewHeaderTrans(int userId, int paymentId, DateTime date)
        {
            HeaderTransaction trans = new HeaderTransaction();
            trans.UserID = userId;
            trans.PaymentTypeID = paymentId;
            trans.Date = date;
            return trans;
        }

        public static DetailTransaction CreateNewDetailTrans(int transId, int productId, int quantity)
        {
            DetailTransaction detail = new DetailTransaction();
            detail.TransactionID = transId;
            detail.ProductID = productId;
            detail.Quantity = quantity;
            return detail;
        }

        public static TransactionModel createTransObject(dynamic xdata)
        {
            TransactionModel tempData = new TransactionModel();
            tempData.transDate = xdata.Date;
            tempData.paymentType = xdata.PaymentTypeName;
            tempData.productName = xdata.ProductName;
            tempData.quantity = xdata.Quantity;
            tempData.subTotal = xdata.ProductPrice * xdata.Quantity;
            return tempData;
        }
    }
}