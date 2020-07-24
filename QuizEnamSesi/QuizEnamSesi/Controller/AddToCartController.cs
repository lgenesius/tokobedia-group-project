using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuizEnamSesi.Model;
using QuizEnamSesi.Handler;

namespace QuizEnamSesi.Controller
{
    public class AddToCartController
    {
        public static Boolean AddToCartValidation(User user, int stock, int productId, out string errorMessage)
        {
            Cart cart = AddToCartHandler.returnGetCart(user.Id, productId);
            int equal = AddToCartHandler.returnStock(productId);
            int productStock = equal - stock;
            int cartQuantity = 0;
            if(cart == null)
            {
                cartQuantity = 0;
            }
            else
            {
                cartQuantity = cart.Quantity;
            }
            int stockQuantity = stock + cartQuantity;
            errorMessage = "";

            if (stock <= 0)
            {
                errorMessage = "Stock input must be more than 0";
                return false;
            }
            else if (stock > equal)
            {
                errorMessage = "Stock input is too much";
                return false;
            }
            else if (stockQuantity > equal)
            {
                errorMessage = "Input must be less than " + (equal - cart.Quantity);
                return false;
            }
            else if (AddToCartHandler.returnGetCart(user.Id, productId) == null)
            {
                AddToCartHandler.InsertNewCartHandler(user.Id, productId, stock);
                return true;
            }
            else
            {
                AddToCartHandler.UpdateQuantityCart(user.Id, productId, stock);
                return true;
            }
        }
    }
}