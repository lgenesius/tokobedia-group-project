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
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["user"] != null)
            {
                Response.Redirect("Home.aspx");
            }
            SetField();
        }

        private void SetField()
        {
            if (!Page.IsPostBack)
            {
                TxtEmail.Text = null;
                TxtPassword.Text = null;
                TxtConfirmPassword.Text = null;
                TxtName.Text = null;
                RadioGender.Text = null;
            }
        }

        protected void BtnRegister_Click(object sender, EventArgs e)
        {
            string email = TxtEmail.Text.ToString();
            string name = TxtName.Text.ToString();
            string password = TxtPassword.Text.ToString();
            string confirmPassword = TxtConfirmPassword.Text.ToString();
            string gender = RadioGender.Text.ToString();

            Boolean isFormatCorrect = DataValidation(email, name, password, confirmPassword, gender);

            if (isFormatCorrect == true)
            {
                UserRepository.InsertNewUser(email, name, password, gender);
                LblError.Text = "Registration Success";
                Response.Redirect("Home.aspx");
            }
            else
            {
                LblError.Text = "Registration Failed";
            }
        }

        private Boolean DataValidation(string email, string name, string password, string confirmPassword, string gender)
        {
            return RegisterController.RegisterValidation(email, name, password, confirmPassword, gender);
        }

        protected void BtnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx");
        }
    }
}