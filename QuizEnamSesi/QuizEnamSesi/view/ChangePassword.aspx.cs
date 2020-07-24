using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using QuizEnamSesi.Controller;

namespace QuizEnamSesi.view
{
    public partial class ChangePassword : System.Web.UI.Page
    {

        private Model.User data;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
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
                    return;
                }
            }
        }

        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            string oldPassword = TxtOldPassword.Text.ToString();
            string newPassword = TxtNewPassword.Text.ToString();
            string confirmPass = TxtConfirmPassword.Text.ToString();

            Boolean isFormatCorrect = DataValidation(oldPassword, newPassword, confirmPass);

            if(isFormatCorrect == true)
            {
                int id = Int32.Parse(data.Id.ToString());
                ChangePasswordController.UpdateUserPasswordController(id, newPassword);
                Response.Redirect("Profile.aspx");
            }
        }

        protected Boolean DataValidation(string oldPass, string newPass, string confirmPass)
        {
            data = (Model.User)Session["user"];
            string errorMessage = "";

            Boolean isSuccess = ChangePasswordController.DataValidationController(oldPass, newPass, confirmPass, data, out errorMessage);
            LblError.Text = errorMessage;
            return isSuccess;
        }
    }
}