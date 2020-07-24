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
    public partial class UpdateProductType : System.Web.UI.Page
    {

        private int typeId;
        string oldTypeName;

        protected void Page_Load(object sender, EventArgs e)
        {
            GetUserCookies();
            CheckQueryString();
            SetTypeData();
        }

        private void SetTypeData()
        {
            typeId = Int32.Parse(Request.QueryString["productTypeId"]);
            ProductType currData = UpdateProductTypeController.GetProductTypeController(typeId);
            oldTypeName = currData.Name.ToString();
            if (!Page.IsPostBack)
            {
                TxtTypeName.Text = currData.Name.ToString();
                TxtDescription.Text = currData.Description.ToString();
            }
        }

        private void CheckQueryString()
        {
            if(Request.QueryString.Count <= 0)
            {
                Response.Redirect("ViewProductType.aspx");
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

            Model.User curr = (Model.User)Session["user"];
            if (curr.RoleId != 1)
            {
                Response.Redirect("Home.aspx");
            }
        }

        protected void DoUpdateType(object sender, EventArgs e)
        {
            string typeName = TxtTypeName.Text.ToString();
            string desc = TxtDescription.Text.ToString();

            if (DataValidation(typeName, desc) == true)
            {
                UpdateProductTypeController.GetUpdateProductTypeController(typeId, typeName, desc);
                Response.Redirect("ViewProductType.aspx");
            }
        }

        private Boolean DataValidation(string name, string desc)
        {
            string errorMessage = "";
            if(UpdateProductTypeController.ProductTypeValidation(name, desc, oldTypeName, out errorMessage) == false)
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