using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuizEnamSesi.Handler;
using QuizEnamSesi.Model;

namespace QuizEnamSesi.Controller
{
    public class UserController
    {
        public static User GetUserController(int id)
        {
            return UserHandler.GetUserHandler(id);
        }
    }
}