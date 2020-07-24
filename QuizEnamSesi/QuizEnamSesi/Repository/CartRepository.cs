using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuizEnamSesi.Model;
using QuizEnamSesi.Factory;

namespace QuizEnamSesi.Repository
{
    public class CartRepository
    {
        static tokobediaModelContainer db = new tokobediaModelContainer();

        public static void InsertNewCart(int userId, int productId, int quantity)
        {
            Cart newCart = CartFactory.CreateNewCart(userId, productId, quantity);
            db.Carts.Add(newCart);
            db.SaveChanges();
        }

        public static Product GetProduct(int id)
        {
            return (from p in db.Products
                    where p.ID == id
                    select p).FirstOrDefault();
        }

        public static Cart GetCart(int userId, int productId)
        {
            return (from c in db.Carts
                    where c.ProductID == productId && c.UserID == userId
                    select c).FirstOrDefault();
        }

        public static Cart GetUserId(int userId)
        {
            return (from c in db.Carts
                    where c.UserID == userId
                    select c).FirstOrDefault();
        }

        public static void UpdateStock(int productId, int stock)
        {
            Product prod = GetProduct(productId);
            prod.Stock = stock;
            db.SaveChanges();
        }

        public static Cart GetCartQuantity(int userId, int productId)
        {
            return (from c in db.Carts
                    where c.UserID == userId && c.ProductID == productId
                    select c).FirstOrDefault();
        }

        public static void UpdateQuantity1(int userId, int productId, int quantity)
        {
            Cart cart = GetCartQuantity(userId, productId);
            db.SaveChanges();
        }

        public static void UpdateQuantity(int userId, int productId, int quantity)
        {
            Cart cart = GetCartQuantity(userId, productId);
            cart.Quantity += quantity;
            db.SaveChanges();
        }

        public static List<CartModel> GetAllInCart(int userId)
        {
            List<CartModel> allData = new List<CartModel>();
            var result = (from x in db.Carts
                          join y in db.Products on x.ProductID equals y.ID
                          where x.UserID == userId
                          select new
                          {
                              Id = y.ID,
                              Name = y.Name,
                              Price = y.Price,
                              Quantity = x.Quantity,
                          }).ToList();

            foreach (var xdata in result)
            {
                allData.Add(CartFactory.createCartObject(xdata));
            }

            return allData;
        }

        public static void DeleteItemsInCart(int userId, int productId)
        {
            Cart toDelete = GetCartQuantity(userId, productId);
            db.Carts.Remove(toDelete);
            db.SaveChanges();
        }

        public static void UpdateCart(Cart cart)
        {
            Cart cartToUpdate = GetCartQuantity(cart.UserID, cart.ProductID);
            cartToUpdate.Quantity = cart.Quantity;
            db.SaveChanges();
        }
    }
}