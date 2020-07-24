using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuizEnamSesi.Model;
using QuizEnamSesi.Handler;

namespace QuizEnamSesi.Controller
{
    public class CartController
    {
        public static List<CartModel> getAllCartData(int userId)
        {
            return CartHandler.getAllCartData(userId);
        }

        public static string getGrandTotal(List<CartModel> allCart)
        {
            int GrandTotal = 0;
            foreach(CartModel currCart in allCart)
            {
                GrandTotal += (currCart.subTotal);
            }

            return GrandTotal.ToString();
        }

        public static Boolean InsertHeaderController(int userId, int paymentId, List<CartModel> allCart, out string errorMessage)
        {
            errorMessage = "";
            if (CartHandler.returnUserId(userId) == null)
            {
                errorMessage = "You don't have any Item in Carts";
                return false;
            }
            DateTime date = DateTime.Now;
            int transId = CartHandler.InsertHeaderHandler(userId, paymentId, date).ID;
            foreach(CartModel currCart in allCart)
            {
                CartHandler.InsertDetailHandler(transId, currCart.productId, currCart.quantity);
                CartHandler.UpdateMinHandler(currCart.productId, currCart.quantity);
                CartHandler.deleteItemsInCartHandler(userId, currCart.productId);
            }
            return true;
        }

        public static void DeleteItemsInCartController(int userId, int productId)
        {
            CartHandler.deleteItemsInCartHandler(userId, productId);
        }

        public static Cart getCartController(int userId, int productId)
        {
            return CartHandler.getCartHandler(userId, productId);
        }

        public static string UpdateCartController(Cart cart, int productId)
        {
            int equal = AddToCartHandler.returnStock(productId);
            if (cart.Quantity < 0)
            {
                return "Input Invalid!";
            }
            else if (equal < cart.Quantity)
            {
                return "There's not enough stock for that product";
            }
            CartHandler.UpdateCartHandler(cart);
            return "Success";
        }

        public static Boolean CheckOutValidation()
        {
            return true;
        }


    }
}