using QuizEnamSesi.Model;
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
    public partial class ViewProductType : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CheckUserAndSession();
            SetData();
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

            if(currUser.RoleId != 1)
            {
                Response.Redirect("Home.aspx");
            }
        }

        private void SetData()
        {
            List<ProductType> allProductType = ViewProductTypeController.GetAllProductTypeController();
            GridProductType.DataSource = allProductType;
            GridProductType.DataBind();
        }

        protected void BtnUpdateProductType_Click(object sender, EventArgs e)
        {
            int productTypeId = Int32.Parse((sender as LinkButton).CommandArgument);

            Response.Redirect("UpdateProductType.aspx?productTypeId=" + productTypeId);
        }

        protected void BtnDeleteProductType_Click(object sender, EventArgs e)
        {
            int productTypeId = Int32.Parse((sender as LinkButton).CommandArgument);
            string errorMessage = "";
            if (ViewProductTypeController.DeleteProductTypeController(productTypeId, out errorMessage)== false)
            {
                Response.Redirect("ViewProductType.aspx");
            }
            else
            {
                LblError.Text = errorMessage;
            }
        }

        protected void BtnInsertProductType_Click(object sender, EventArgs e)
        {
            Response.Redirect("InsertProductType.aspx");
        }

        protected void BtnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx");
        }
    }
}