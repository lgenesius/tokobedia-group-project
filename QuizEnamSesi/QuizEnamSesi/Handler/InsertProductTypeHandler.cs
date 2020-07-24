using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuizEnamSesi.Repository;

namespace QuizEnamSesi.Handler
{
    public class InsertProductTypeHandler
    {
        public static void InsertNewProductTypeHandler(string name, string desc)
        {
            ProductTypeRepository.InsertNewProductType(name, desc);
        }

        public static int CheckProductTypeHandler(string name)
        {
            return ProductTypeRepository.CheckProductType(name);
        }
    }
}