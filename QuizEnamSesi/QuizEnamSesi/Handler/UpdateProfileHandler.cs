using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuizEnamSesi.Repository;

namespace QuizEnamSesi.Handler
{
    public class UpdateProfileHandler
    {
        public static void UpdateUserDataHandler(string email, string name, string gender, int id)
        {
            UserRepository.UpdateUserData(email, name, gender, id);
        }

        public static int CheckIfEmailExistHandler(string email)
        {
            return UserRepository.CheckIfEmailExist(email);
        }
    }
}