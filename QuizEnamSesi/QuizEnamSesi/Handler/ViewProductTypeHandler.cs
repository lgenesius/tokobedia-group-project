using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuizEnamSesi.Repository;
using QuizEnamSesi.Model;

namespace QuizEnamSesi.Handler
{
    public class ViewProductTypeHandler
    {
        public static List<ProductType> GetAllProductTypeHandler()
        {
            return ProductTypeRepository.GetAllProductType();
        }

        public static Boolean CheckReferencesHandler(int id)
        {
            return ProductTypeRepository.CheckReferences(id);
        }

        public static void DeleteProductTypeHandler(int id)
        {
            ProductTypeRepository.DeleteProductType(id);
        }
    }
}