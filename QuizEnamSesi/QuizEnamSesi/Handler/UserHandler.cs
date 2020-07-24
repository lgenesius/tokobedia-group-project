using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuizEnamSesi.Repository;
using QuizEnamSesi.Model;

namespace QuizEnamSesi.Handler
{
    public class UserHandler
    {
        public static User GetUserHandler(int id)
        {
            return UserRepository.GetUser(id);
        }
    }
}