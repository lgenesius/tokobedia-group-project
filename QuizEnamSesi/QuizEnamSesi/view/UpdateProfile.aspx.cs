using QuizEnamSesi.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using QuizEnamSesi.Controller;

namespace QuizEnamSesi.view
{
    public partial class UpdateProfile : System.Web.UI.Page
    {

        private string oldEmail;
        private Model.User data;

        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["user"] == null)
            {
                if(Request.Cookies.Get("user") != null)
                {
                    HttpCookie cookie = Request.Cookies.Get("user");
                    int id = Int32.Parse(cookie.Value);
                    var loggedUser = UserController.GetUserController(id);
                    Session["user"] = loggedUser;

                    oldEmail = loggedUser.Email.ToString();
                }
                else
                {
                    Response.Redirect("Home.aspx");
                    return;
                }
            }
            else if(Session["user"] != null)
            {
                data = (Model.User)Session["user"];

                oldEmail = data.Email.ToString();
            }

            SetUserData();
        }

        private void SetUserData()
        {
            if (!Page.IsPostBack)
            {
                data = (Model.User)Session["user"];

                TxtEmail.Text = data.Email.ToString();
                TxtName.Text = data.Name.ToString();
                RadioGender.Text = data.Gender.ToString();
            }
            
        }

        protected void BtnUpdateProfile_Click(object sender, EventArgs e)
        {

            data = (Model.User)Session["user"];
            
            string newEmail = TxtEmail.Text.ToString();
            string newName = TxtName.Text.ToString();
            string newGender = RadioGender.Text.ToString();
            int id = Int32.Parse(data.Id.ToString());

            if (UpdateProfileController.UpdateProfileValidation(newEmail, newName, newGender,oldEmail) == true)
            {
                UpdateProfileController.UpdateUserDataController(newEmail, newName, newGender, id);

                Response.Redirect("Profile.aspx");
            }
            else
            {
                LblError.Text = "Enter the right ID!";
            }

            
        }
    }

    
}