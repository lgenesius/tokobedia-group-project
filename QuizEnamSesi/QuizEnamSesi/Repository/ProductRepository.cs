using QuizEnamSesi.Factory;
using QuizEnamSesi.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace QuizEnamSesi.Repository
{
    public static class ProductRepository
    {
        static tokobediaModelContainer db = new tokobediaModelContainer();
        static Random rand = new Random();

        public static List<Product> GetFiveRandomProduct()
        {
            List<Product> randomProduct = new List<Product>();

            List<Product> allProduct = GetAllProduct();

            if (allProduct.Count < 5) return allProduct;

            for(int i = 0; i < 5; i++)
            {
                int idx = rand.Next(allProduct.Count);
                randomProduct.Add(allProduct.ElementAt(idx));
                allProduct.Remove(allProduct.ElementAt(idx));
            }

            return randomProduct;
        }

        public static List<Product> GetAllProduct()
        {
            return db.Products.ToList();
        }
        
        public static void InsertNewProduct(string name, int productType, int stock, int price)
        {
            Product newProduct = ProductFactory.CreateNewProduct(productType, name, stock, price);
            db.Products.Add(newProduct);
            db.SaveChanges();
        }

        public static Product GetProduct(int id)
        {
            return (from p in db.Products
                   where p.ID == id
                   select p).FirstOrDefault();
        }

        public static void UpdatePlustStock(int productId, int stock)
        {
            Product prod = GetProduct(productId);
            prod.Stock += stock;
            db.SaveChanges();
        }

        public static void UpdateMinStock(int productId, int stock)
        {
            Product prod = GetProduct(productId);
            prod.Stock -= stock;
            db.SaveChanges();
        }

        public static void DeleteProduct(int id)
        {
            Product toDelete = GetProduct(id);
            db.Products.Remove(toDelete);
            db.SaveChanges();
        }

        public static void UpdateProduct(string name, int stock, int price, int id)
        {
            Product prod = GetProduct(id);
            prod.Name = name;
            prod.Stock = stock;
            prod.Price = price;
            db.SaveChanges();
        }

        public static Boolean CheckReferences(int id)
        {
            int detailRef = (from detail in db.DetailTransactions
                             where detail.ProductID == id
                             select detail).Count();

            if (detailRef > 0) return false;
            return true;
        }

        public static Product checkProductId(int id)
        {
            Product product = db.Products.Where(a => a.ID == id).FirstOrDefault();
            return product;
        }

    }
}