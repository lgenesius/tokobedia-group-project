using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuizEnamSesi.Model
{
    public class CartModel
    {
        public int productId { get; set; }
        public string productName { get; set; }
        public int productPrice { get; set; }
        public int quantity { get; set; }
        public int subTotal { get; set; }
    }
}