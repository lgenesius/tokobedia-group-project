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
    public partial class UpdateProduct : System.Web.UI.Page
    {

        private Model.User curr;
        private int productId;

        protected void Page_Load(object sender, EventArgs e)
        {
            GetUserCookies();
            CheckQueryString();
            SetProductData();
        }

        private void CheckQueryString()
        {
            if(Request.QueryString.Count <= 0)
            {
                Response.Redirect("ViewProduct.aspx");
            }
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

            curr = (Model.User)Session["user"];
            if (Int32.Parse(curr.RoleId.ToString()) != 1)
            {
                Response.Redirect("Home.aspx");
            }
        }

        private void SetProductData()
        {
            productId = Int32.Parse(Request.QueryString["productId"]);
            if (!Page.IsPostBack)
            {
                Product currData = UpdateProductController.GetProductController(productId);
                TxtNewName.Text = currData.Name;
                TxtNewStock.Text = currData.Stock.ToString();
                TxtNewPrice.Text = currData.Price.ToString();

            }
        }

        protected void BtnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("ViewProduct.aspx");
        }

        protected void UpdateData(object sender, EventArgs e)
        {
            string newName = TxtNewName.Text.ToString();
            string newStock = TxtNewStock.Text.ToString();
            string newPrice = TxtNewPrice.Text.ToString();

            if (DataValidation(newName, newStock, newPrice) == true)
            {
                UpdateProductController.GetUpdateProductController(newName, Int32.Parse(newStock), Int32.Parse(newPrice), productId);
                Response.Redirect("ViewProduct.aspx");
            }
        }

        private Boolean DataValidation(string name, string stock, string price)
        {
            string errorMessage = "";
            if(UpdateProductController.UpdateProductValidation(name, stock, price, out errorMessage)==false)
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

    }
}