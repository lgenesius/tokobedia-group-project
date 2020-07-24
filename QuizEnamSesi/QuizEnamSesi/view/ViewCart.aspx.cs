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
    public partial class ViewCart : System.Web.UI.Page
    {
        int userId = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            CheckSessionAndUserType();
            ShowAllItem();
            showPaymentList();
        }

        private void CheckSessionAndUserType()
        {
            if (Session["user"] == null)
            {
                if (Request.Cookies.Get("user") != null)
                {
                    HttpCookie cookie = Request.Cookies.Get("user");
                    userId = Int32.Parse(cookie.Value);
                    var loggedUser = UserController.GetUserController(userId);
                    Session["user"] = loggedUser;
                }
                else
                {
                    return;
                }
            }
        }

        private void ShowAllItem()
        {
            Model.User currUser = (Model.User)Session["user"];
            List<CartModel> allCart = CartController.getAllCartData(Int32.Parse(currUser.Id.ToString()));

            if (allCart.Count > 0)
            {
                GridAllCart.DataSource = allCart;
                GridAllCart.DataBind();
                GrandTotal.Text = "Rp. " + CartController.getGrandTotal(allCart);
            }
        }

        private void showPaymentList()
        {
            tokobediaModelContainer db = new tokobediaModelContainer();
            var query = from g in db.PaymentTypes
                        select new
                        {
                            PaymentTypeId = g.ID,
                            PaymentTypeName = g.Type       
                        };
            GridView1.DataSource = query.ToList();
            GridView1.DataBind();
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx");
        }

        protected void UpdateCartItem(object product, EventArgs e)
        {
            int productId = Int32.Parse((product as LinkButton).CommandArgument);
            //Model.User currUser = (Model.User)Session["user"];
            //int userId = Int32.Parse(currUser.Id.ToString());
            Response.Redirect("UpdateCart.aspx?productId=" + productId);
        }

        protected void DeleteCartItem(object product, EventArgs e)
        {
            int productId = Int32.Parse((product as LinkButton).CommandArgument);
            Model.User currUser = (Model.User)Session["user"];
            int userId = Int32.Parse(currUser.Id.ToString());
            CartController.DeleteItemsInCartController(userId, productId);
            Response.Redirect("ViewCart.aspx");
        }

        protected void BtnCheckout_Click(object sender, EventArgs e)
        {
            Model.User currUser = (Model.User)Session["user"];
            List<CartModel> allCart = CartController.getAllCartData(Int32.Parse(currUser.Id.ToString()));
            string errorMessage = "";
            int parsedValue;
            if (TBPayment.Text == "")
            {
                LblError.Visible = true;
                LblError.Text = "Please Insert The Payment ID";
                return;
            }
            int paymentId = Int32.Parse(TBPayment.Text.ToString());
            if (!int.TryParse(TBPayment.Text, out parsedValue))
            {
                LblError.Visible = true;
                LblError.Text = "Please specify a number only !!";
            }
            bool isTrue = CartController.InsertHeaderController(currUser.Id, paymentId, allCart, out errorMessage);
            if(isTrue == false)
            {
                LblError.Visible = true;
                LblError.Text = errorMessage;
            }
            else
            {
                Response.Redirect("TransactionHistory.aspx");
            }
        }
    }
}