using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuizEnamSesi.Model;

namespace QuizEnamSesi.Repository
{
    public class DatabaseSingleton
    {
        private static tokobediaModelContainer db;

        private DatabaseSingleton() { }

        public static tokobediaModelContainer GetInstance()
        {
            if(db == null)
            {
                db = new tokobediaModelContainer();
            }
            return db;
        }
    }
}