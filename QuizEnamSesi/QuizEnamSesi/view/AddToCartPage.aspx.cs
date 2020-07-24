using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using QuizEnamSesi.Model;
using QuizEnamSesi.Controller;

namespace QuizEnamSesi.view
{
    public partial class AddToCartPage : System.Web.UI.Page
    {
        private Model.User curr;
        private int productId;
        protected void Page_Load(object sender, EventArgs e)
        {
            GetUserCookies();
            CheckQueryString();
            SetProductData();
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
        }

        private void CheckQueryString()
        {
            if (Request.QueryString.Count <= 0)
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
                LabelName.Text = currData.Name;
                LabelPrice.Text = currData.Price.ToString();
                LabelStock.Text = currData.Stock.ToString();
                LabelType.Text = currData.ProductType.Name;
            }
        }

        protected void BtnAddCart_Click(object sender, EventArgs e)
        {
            int parsedValue;
            string errorMessage = "";
            if (!int.TryParse(TBStock.Text, out parsedValue))
            {
                LblError.Visible = true;
                LblError.Text = "Please specify a number only !!";
            }
            else
            {
                int stock = Int32.Parse(TBStock.Text);
                bool isTrue = AddToCartController.AddToCartValidation(curr, stock, Int32.Parse(Request.QueryString["productId"]), out errorMessage);
                condition(isTrue, errorMessage);
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("ViewProduct.aspx");
        }

        private void condition(bool isTrue, string errorMessage)
        {
            if (isTrue)
            {
                Response.Redirect("ViewCart.aspx");
            }
            else
            {
                LblError.Visible = true;
                LblError.Text = errorMessage;
            }
        }
    }
}