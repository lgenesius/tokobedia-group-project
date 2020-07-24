using QuizEnamSesi.Factory;
using QuizEnamSesi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuizEnamSesi.Repository
{
    public static class UserRepository
    {
        static tokobediaModelContainer db = new tokobediaModelContainer();

        public static int CheckIfEmailExist(string email)
        {
            int count;
            return count = (from user in db.Users
                         where user.Email.Equals(email)
                         select user).Count();   
        }

        public static void InsertNewUser(string email, string name, string password, string gender)
        {
            User newUser = UserFactory.CreateNewUser(email, name, password, gender);
            db.Users.Add(newUser);
            db.SaveChanges();
        }

        public static User GetUser(string email, string password)
        {
            User data = (from user in db.Users
                         where user.Email.Equals(email) && user.Password.Equals(password)
                         select user).FirstOrDefault();

            return data;
        }

        public static User GetUser(int id)
        {
            User data = (from user in db.Users
                         where user.Id == id
                         select user).FirstOrDefault();

            return data;
        }

        public static void UpdateUserData(string email, string name, string gender, int id)
        {
            User data = GetUser(id);
            data.Email = email;
            data.Name = name;
            data.Gender = gender;

            db.SaveChanges();
        }

        public static void UpdateUserPassword(int id, string newPassword)
        {
            User data = GetUser(id);
            data.Password = newPassword;
            db.SaveChanges();
        }

        public static List<User> GetAllUser()
        {
            return db.Users.ToList();
        }

        public static void ChangeUserStatus(int id)
        {
            User data = GetUser(id);
            if (data.Status == "Active") data.Status = "Blocked";
            else data.Status = "Active";
            db.SaveChanges();
        }
    }
}