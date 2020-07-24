using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuizEnamSesi.Model;
using QuizEnamSesi.Repository;

namespace QuizEnamSesi.Handler
{
    public class CartHandler
    {
        public static List<CartModel> getAllCartData(int userId)
        {
            return CartRepository.GetAllInCart(userId);
        }

        public static void deleteItemsInCartHandler(int userId, int productId)
        {
            CartRepository.DeleteItemsInCart(userId, productId);
        }

        public static Cart getCartHandler(int userId, int productId)
        {
            return CartRepository.GetCartQuantity(userId, productId);
        }

        public static void UpdateCartHandler(Cart cart)
        {
            if (cart.Quantity == 0)
            {
                CartRepository.DeleteItemsInCart(cart.UserID, cart.ProductID);
            }
            else
            {
                CartRepository.UpdateCart(cart);
            }
        }

        public static void UpdatePlusHander(int productId, int stock)
        {
            ProductRepository.UpdatePlustStock(productId, stock);
        }

        public static void UpdateMinHandler(int productId, int stock)
        {
            ProductRepository.UpdateMinStock(productId, stock);
        }

        public static HeaderTransaction InsertHeaderHandler(int userId, int paymentId, DateTime date)
        {
           return TransactionRepository.InsertNewHeaderTrans(userId, paymentId, date);
        }

        public static void InsertDetailHandler(int transId, int productId, int quantity)
        {
            TransactionRepository.InsertNewDetailTrans(transId, productId, quantity);
        }

        public static Cart returnUserId(int userId)
        {
            return CartRepository.GetUserId(userId);
        }
    }
}