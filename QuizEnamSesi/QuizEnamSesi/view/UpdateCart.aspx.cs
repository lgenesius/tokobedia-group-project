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
    public partial class UpdateCart : System.Web.UI.Page
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
            if (Int32.Parse(curr.RoleId.ToString()) != 2)
            {
                Response.Redirect("Home.aspx");
            }
        }

        private void CheckQueryString()
        {
            if (Request.QueryString.Count <= 0)
            {
                Response.Redirect("ViewCart.aspx");
            }
        }

        private void SetProductData()
        {
            productId = Int32.Parse(Request.QueryString["productId"]);
            Model.User currUser = (Model.User)Session["user"];
            if (!Page.IsPostBack)
            {
                Cart currData = CartController.getCartController(Int32.Parse(currUser.Id.ToString()), productId);
                TxtItemQuantity.Text = currData.Quantity.ToString();
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("ViewCart.aspx");
        }

        protected void UpdateData(object sender, EventArgs e)
        {
            Cart cart = new Cart();
            Model.User currUser = (Model.User)Session["user"];
            cart.Quantity = Int32.Parse(TxtItemQuantity.Text.ToString());
            cart.ProductID = Int32.Parse(Request.QueryString["productId"]);
            cart.UserID = Int32.Parse(currUser.Id.ToString());
            Cart currData = CartController.getCartController(Int32.Parse(currUser.Id.ToString()), productId);

            string result = CartController.UpdateCartController(cart, Int32.Parse(Request.QueryString["productId"]));

            if (result.Equals("Success"))
            {
                Response.Redirect("ViewCart.aspx");
            }
            else
            {
                TxtError.Text = result;
            }
        }
    }
}