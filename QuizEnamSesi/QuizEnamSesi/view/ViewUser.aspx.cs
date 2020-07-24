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
    public partial class ViewUser : System.Web.UI.Page
    {
        private Model.User curr;

        protected void Page_Load(object sender, EventArgs e)
        {
            GetUserCookies();
            SetAllUser();
        }

        private void SetAllUser()
        {
                List<User> user = ViewUserController.GetAllUserController();
                GridAllUser.DataSource = user;
                GridAllUser.DataBind();
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

        protected void BtnChangeStatus_Click(object sender, EventArgs e)
        {
            int userId = Int32.Parse((sender as LinkButton).CommandArgument);
            ViewUserController.ChangeUserStatusController(userId);
            Response.Redirect("ViewUser.aspx");
        }

        protected void BtnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx");
        }

        protected Boolean IsOwnAccount(int id)
        {
            return id != curr.Id;
        }
    }
}