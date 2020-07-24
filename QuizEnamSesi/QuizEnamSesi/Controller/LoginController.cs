using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuizEnamSesi.Model;
using QuizEnamSesi.Handler;

namespace QuizEnamSesi.Controller
{
    public class LoginController
    {
        public static User GetUserController(string email,string password, out string errorMessage)
        {
            errorMessage = "";
            User userLogin = LoginHandler.GetUserHandler(email, password);
            if (userLogin == null)
            {
                errorMessage = "User not found";
            }
            else if (userLogin.Status.Equals("Blocked"))
            {
                errorMessage = "User banned, not permitted to login";
            }
            return userLogin;          
        }
    }
}