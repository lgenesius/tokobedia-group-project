using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuizEnamSesi.Handler;

namespace QuizEnamSesi.Controller
{
    public class RegisterController
    {
        public static void InsertNewUserController(string email, string name, string password, string gender, bool isFormatCorrect)
        {
           
            RegisterHandler.InsertNewUserHandler(email, name, password, gender);
        }

        public static Boolean RegisterValidation(string email, string name, string password, string confirmPassword, string gender)
        {
            if (email == String.Empty || name == String.Empty || password == String.Empty || gender == String.Empty) return false;
            if (password.Equals(confirmPassword) == false) return false;
            if (RegisterHandler.CheckIfEmailExistHandler(email) > 0) return false;
            return true;
        }
    }
}