using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuizEnamSesi.Model;

namespace QuizEnamSesi.Factory
{
    public class CartFactory
    {
        public static Cart CreateNewCart(int userId, int productId, int quantity)
        {
            Cart cart = new Cart();
            cart.UserID = userId;
            cart.ProductID = productId;
            cart.Quantity = quantity;
            return cart;
        }

        public static CartModel createCartObject(dynamic xdata)
        {
            CartModel tempData = new CartModel();
            tempData.productId = xdata.Id;
            tempData.productName = xdata.Name;
            tempData.productPrice = xdata.Price;
            tempData.quantity = xdata.Quantity;
            tempData.subTotal = xdata.Price * xdata.Quantity;
            return tempData;
        }
    }
}