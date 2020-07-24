using QuizEnamSesi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using QuizEnamSesi.Controller;

namespace QuizEnamSesi.view
{
    public partial class Login : System.Web.UI.Page
    {

        tokobediaModelContainer db = new tokobediaModelContainer();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] != null)
            {
                Response.Redirect("home.aspx");
            }
            if (Session["user"] == null)
            {
                if (Request.Cookies.Get("user") != null)
                {
                    HttpCookie cookie = Request.Cookies.Get("user");
                    int id = Int32.Parse(cookie.Value);
                    var loggedUser = UserController.GetUserController(id);
                    Session["user"] = loggedUser;
                }
            }
        }

        protected void BtnLogin_Click(object sender, EventArgs e)
        {
            string email = LoginEmail.Text.ToString();
            string password = LoginPassword.Text.ToString();
            string errorMessage = "";

            User userLogin = LoginController.GetUserController(email,password, out errorMessage);
            LblError.Text = errorMessage;
            if(LblError.Text == "User not found" || LblError.Text == "User banned, not permitted to login")
            {
                return;
            }
            MakeNewSessionAndCookies(userLogin);
        }

        private void MakeNewSessionAndCookies(User loggedIn)
        {
            Session["user"] = loggedIn;

            if (ChkRemember.Checked == true)
            {
                HttpCookie cookies = new HttpCookie("user", loggedIn.Id.ToString());
                cookies.Expires = DateTime.Now.AddHours(3);
                Response.Cookies.Add(cookies);
            }
            Response.Redirect("Home.aspx");
        }
        protected void BtnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx");
        }
    }
}