using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using QuizEnamSesi.Controller;
using QuizEnamSesi.Model;

namespace QuizEnamSesi.view
{
    public partial class TransactionReportPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            TransactionReport newTransRep = new TransactionReport();
            CrystalReportViewer1.ReportSource = newTransRep;
            newTransRep.SetDataSource(GenerateData(TransactionReportController.GetTransaction()));          
        }

        private DataSet1 GenerateData(List<HeaderTransaction> transactionList)
        {
            DataSet1 newDataset = new DataSet1();
            var headerTransactionTable = newDataset.HeaderTransaction;
            var detailTransactionTable = newDataset.DetailTransaction;

            foreach(var ht in transactionList)
            {
                var headerTransactionRow = headerTransactionTable.NewRow();
                headerTransactionRow["TransactionId"] = ht.ID;
                headerTransactionRow["Username"] = ht.User.Name;
                headerTransactionRow["Date"] = ht.Date;
                headerTransactionTable.Rows.Add(headerTransactionRow);

                foreach(var dt in ht.DetailTransactions)
                {
                    var detailTransactionRow = detailTransactionTable.NewRow();
                    detailTransactionRow["TransactionId"] = ht.ID;
                    detailTransactionRow["ProductName"] = dt.Product.Name;
                    detailTransactionRow["Quantity"] = dt.Quantity;
                    detailTransactionRow["SubTotal"] = dt.Product.Price * dt.Quantity;
                    detailTransactionTable.Rows.Add(detailTransactionRow);
                }
            }
            return newDataset;
        }
    }
}