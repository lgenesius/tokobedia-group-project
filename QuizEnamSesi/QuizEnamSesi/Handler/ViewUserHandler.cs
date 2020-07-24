using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuizEnamSesi.Repository;
using QuizEnamSesi.Model;

namespace QuizEnamSesi.Handler
{
    public class ViewUserHandler
    {
        public static List<User> GetAllUserHandler()
        {
            return UserRepository.GetAllUser();
        }

        public static void ChangeUserStatusHandler(int id)
        {
            UserRepository.ChangeUserStatus(id);
        }
    }
}