using QuizEnamSesi.Factory;
using QuizEnamSesi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuizEnamSesi.Repository
{
    public static class ProductTypeRepository
    {
        static tokobediaModelContainer db = new tokobediaModelContainer();
        public static List<ProductType> GetAllProductType()
        {
            return db.ProductTypes.ToList();
        }

        public static Boolean CheckProductType(int id)
        {
            ProductType data = (from type in db.ProductTypes
                                where type.ID == id
                                select type).FirstOrDefault();

            if (data == null) return false;
            return true;
        }

        public static int CheckProductType(string name)
        {
            int count = (from type in db.ProductTypes
                         where type.Name.ToLower().Equals(name.ToLower())
                         select type).Count();

            return count;
        }

        public static void InsertNewProductType(string name, string desc)
        {
            ProductType newProduct = ProductTypeFactory.CreateNewProductType(name, desc);
            db.ProductTypes.Add(newProduct);
            db.SaveChanges();
        }

        public static Boolean CheckReferences(int id)
        {
            int isReferenced = (from prod in db.Products
                                where prod.ProductTypeID == id
                                select prod).Count();

            if (isReferenced > 0) return true;
            return false;
        }

        public static ProductType GetProductType(int id)
        {
            return (from type in db.ProductTypes
                    where type.ID == id
                    select type).FirstOrDefault();
        }

        public static void DeleteProductType(int id)
        {
            ProductType toDelete = GetProductType(id);
            db.ProductTypes.Remove(toDelete);
            db.SaveChanges();
        }

        public static void UpdateProductType(int id, string name, string description)
        {
            ProductType toUpdate = GetProductType(id);
            toUpdate.Name = name;
            toUpdate.Description = description;
            db.SaveChanges();
        }
    }
}