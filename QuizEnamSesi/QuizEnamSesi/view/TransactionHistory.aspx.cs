using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using QuizEnamSesi.Controller;
using QuizEnamSesi.Model;

namespace QuizEnamSesi.view
{
    public partial class TransactionHistory : System.Web.UI.Page
    {
        int userId = 0;
        private Model.User userNow;
        protected void Page_Load(object sender, EventArgs e)
        {
            CheckSessionAndUserType();
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx");
        }

        private void showAllItem()
        {
            Model.User currUser = (Model.User)Session["user"];
            List<TransactionModel> allCart = TransactionController.getHistoryData(Int32.Parse(currUser.Id.ToString()));

            if(allCart.Count > 0)
            {
                GridView1.DataSource = allCart;
                GridView1.DataBind();
                GrandTotal.Text = "Rp. " + TransactionController.getGrandTotal(allCart);
            }
        }

        private void showAllHistory()
        {
            Model.User currUser = (Model.User)Session["user"];
            List<TransactionModel> allCart = TransactionController.getAllHistoryData();

            if (allCart.Count > 0)
            {
                GridView1.DataSource = allCart;
                GridView1.DataBind();
                GrandTotal.Text = "Rp. " + TransactionController.getGrandTotal(allCart);
            }
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
            LoggedUser();
        }

        private void LoggedUser()
        {

            userNow = (Model.User)Session["user"];
            if (userNow.RoleId == 1)
            {
                btnTransReport.Visible = true;
                showAllHistory();
            }
            else
            {
                showAllItem();
            }
        }

        protected void btnTransReport_Click(object sender, EventArgs e)
        {
            Response.Redirect("TransactionReportPage.aspx");
        }
    }
}