using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuizEnamSesi.Repository;

namespace QuizEnamSesi.Handler
{
    public class RegisterHandler
    {
        public static int CheckIfEmailExistHandler(string email)
        {
            return UserRepository.CheckIfEmailExist(email);
        }

        public static void InsertNewUserHandler(string email, string name, string password, string gender)
        {
            UserRepository.InsertNewUser(email, name, password, gender);
        }
    }
}