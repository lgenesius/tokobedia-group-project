using QuizEnamSesi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuizEnamSesi.Factory
{
    public static class UserFactory
    {

        public static User CreateNewUser(string email, string name, string password, string gender)
        {
            User user = new User();
            user.Email = email;
            user.Password = password;
            user.Name = name;
            user.Gender = gender;
            user.RoleId = 2;
            user.Status = "Active";
            return user;
        }
    }
}