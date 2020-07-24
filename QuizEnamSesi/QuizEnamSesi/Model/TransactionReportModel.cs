using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuizEnamSesi.Model
{
    public class TransactionReportModel
    {
        public int transId { get; set; }
        public int userName { get; set; }
        public DateTime transDate { get; set; }
        public string productName { get; set; }
        public int quantity { get; set; }
        public int subTotal { get; set; }
    }
}