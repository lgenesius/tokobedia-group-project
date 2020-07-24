using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuizEnamSesi.Model;
using QuizEnamSesi.Handler;

namespace QuizEnamSesi.Controller
{
    public class ChangePasswordController
    {
        public static Boolean DataValidationController(string oldPass, string newPass, string confirmPass, User data, out string errorMessage)
        {
            errorMessage = "";
            if (oldPass == null || newPass == null || confirmPass == null)
            {
                errorMessage = "All fields must be filled in";
                return false;
            }
            else if(ChangePasswordHandler.GetUserHandler(data.Email.ToString(), oldPass) == null)
            {
                errorMessage = "Old password not found";
                return false;
            }
            else if (newPass.Length < 5)
            {
                errorMessage = "New password must be more than 5 character";
                return false;
            }
            else if(newPass != confirmPass)
            {
                errorMessage = "Failed to confirm new password";
                return false;
            }

            return true;
        }

        public static void UpdateUserPasswordController(int id, string newPassword)
        {
            ChangePasswordHandler.UpdateUserPasswordHandler(id, newPassword);
        }
    }
}