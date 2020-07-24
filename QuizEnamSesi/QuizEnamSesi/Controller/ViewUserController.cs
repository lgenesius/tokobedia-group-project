using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuizEnamSesi.Handler;
using QuizEnamSesi.Model;

namespace QuizEnamSesi.Controller
{
    public class ViewUserController
    {
        public static List<User> GetAllUserController()
        {
            return ViewUserHandler.GetAllUserHandler();
        }

        public static void ChangeUserStatusController(int id)
        {
            ViewUserHandler.ChangeUserStatusHandler(id);
        }
    }
}