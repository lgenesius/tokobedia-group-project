using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using QuizEnamSesi.Controller;

namespace QuizEnamSesi.view
{
    public partial class InsertPaymentType : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CheckUserAndSession();
        }

        private void CheckUserAndSession()
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
                }
            }

            Model.User currUser = (Model.User)Session["user"];

            if (currUser.RoleId != 1)
            {
                Response.Redirect("Home.aspx");
            }
        }

        protected void DoInsertNewType(object sender, EventArgs e)
        {
            string typeName = TxtTypeName.Text.ToString();

            if (DataValidation(typeName) == true)
            {
                InsertPaymentTypeController.InsertNewPaymentTypeController(typeName);
                Response.Redirect("ViewPaymentType.aspx");
            }
        }

        private Boolean DataValidation(string name)
        {
            string errorMessage = "";
            if (InsertPaymentTypeController.PaymentTypeValidation(name, out errorMessage) == false)
            {
                return HandleWrongFormat(errorMessage);
            }
            return true;
        }

        private Boolean HandleWrongFormat(string message)
        {
            LblError.Text = message;
            return false;
        }

        protected void BtnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("ViewPaymentType.aspx");
        }
    }
}