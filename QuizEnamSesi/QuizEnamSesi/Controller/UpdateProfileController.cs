using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuizEnamSesi.Handler;

namespace QuizEnamSesi.Controller
{
    public class UpdateProfileController
    {
        public static void UpdateUserDataController(string email, string name, string gender, int id)
        {
            UpdateProfileHandler.UpdateUserDataHandler(email, name, gender, id);
        }

        public static Boolean UpdateProfileValidation(string email, string name, string gender, string oldEmail)
        {
            if (email == String.Empty || name == String.Empty || gender == String.Empty)
            {
                return false;
            }
            else if (email == oldEmail)
            {
                return true;
            }
            else if (UpdateProfileHandler.CheckIfEmailExistHandler(email) > 0)
            {
                return false;
            }
            return true;
        }
    }
}