using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuizEnamSesi.Repository;
using QuizEnamSesi.Model;

namespace QuizEnamSesi.Handler
{
    public class UpdateProductTypeHandler
    {
        public static ProductType GetProductTypeHandler(int id)
        {
            return ProductTypeRepository.GetProductType(id);
        }

        public static void GetUpdateProductTypeHandler(int id, string name, string description)
        {
           ProductTypeRepository.UpdateProductType(id, name, description);
        }

        public static int CheckProductTypeHandler(string name)
        {
            return ProductTypeRepository.CheckProductType(name);
        }
    }
}