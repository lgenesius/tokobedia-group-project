using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using QuizEnamSesi.Controller;

namespace QuizEnamSesi.view
{
    public partial class Profile : System.Web.UI.Page
    {

        private Model.User currUser;

        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["user"] == null)
            {
                if (Request.Cookies.Get("user") != null)
                {
                    HttpCookie cookie = Request.Cookies.Get("user");
                    int id = Int32.Parse(cookie.Value);
                    var loggedUser = UserController.GetUserController(id);
                    Session["user"] = loggedUser;
                }
                else
                {
                    Response.Redirect("Home.aspx");
                }
            }

            SetUserData();
        }

        private void SetUserData()
        {
            currUser = (Model.User)Session["user"];

            UserEmail.InnerText = currUser.Email.ToString();
            UserName.InnerText = currUser.Name.ToString();
            UserGender.InnerText = currUser.Gender.ToString();
        }

        protected void GoToUpdateProfile(object sender, EventArgs e)
        {
            Response.Redirect("UpdateProfile.aspx");
        }

        protected void GoToUpdatePassword(object sender, EventArgs e)
        {
            Response.Redirect("ChangePassword.aspx");
        }

        protected void BtnToHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx");
        }
    }
}