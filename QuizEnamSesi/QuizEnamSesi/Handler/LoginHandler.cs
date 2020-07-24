using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuizEnamSesi.Model;
using QuizEnamSesi.Repository;

namespace QuizEnamSesi.Handler
{
    public class LoginHandler
    {
        public static User GetUserHandler(string email, string password)
        {
            return UserRepository.GetUser(email, password);
        }
    }
}