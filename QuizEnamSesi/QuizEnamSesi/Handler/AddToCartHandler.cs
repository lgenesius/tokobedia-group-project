using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuizEnamSesi.Model;
using QuizEnamSesi.Repository;

namespace QuizEnamSesi.Handler
{
    public class AddToCartHandler
    {
        public static int returnStock(int productId)
        {
            Product data = ProductRepository.GetProduct(productId);
            return data.Stock;
        }

        public static void InsertNewCartHandler(int userId, int productId, int quantity)
        {
            CartRepository.InsertNewCart(userId, productId, quantity);
        }

        public static void UpdateStockHandler(int productId, int stock)
        {
            CartRepository.UpdateStock(productId, stock);
        }

        public static Cart returnGetCart(int userId, int productId)
        {
            return CartRepository.GetCart(userId, productId);
        }

        public static void UpdateQuantityCart(int userId, int productId, int quantity)
        {
            CartRepository.UpdateQuantity(userId, productId, quantity);
        }
    }
}