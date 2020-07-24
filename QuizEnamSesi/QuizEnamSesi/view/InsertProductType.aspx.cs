using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using QuizEnamSesi.Controller;

namespace QuizEnamSesi.view
{
    public partial class InsertProductType : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GetUserCookies();
        }

        private void GetUserCookies()
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

            Model.User curr = (Model.User)Session["user"];
            if (curr.RoleId != 1)
            {
                Response.Redirect("Home.aspx");
            }
        }

        protected void DoInsertNewType(object sender, EventArgs e)
        {
            string typeName = TxtTypeName.Text.ToString();
            string desc = TxtDescription.Text.ToString();

            if (DataValidation(typeName, desc) == true)
            {
                InsertProductTypeController.InsertNewProductTypeController(typeName, desc);
                Response.Redirect("ViewProductType.aspx");
            }
        }

        private Boolean DataValidation(string name, string desc)
        {
            string errorMessage = "";
            if(InsertProductTypeController.ProductTypeValidation(name, desc, out errorMessage) == false)
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
            Response.Redirect("ViewProductType.aspx");
        }
    }
}