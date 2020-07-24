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
    public partial class UpdatePaymentType : System.Web.UI.Page
    {
        private int typeId;
        string oldTypeName;

        protected void Page_Load(object sender, EventArgs e)
        {
            CheckUserAndSession();
            setData();
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

        private void setData()
        {
            typeId = Int32.Parse(Request.QueryString["id"]);
            PaymentType types = UpdatePaymentTypeController.GetPaymentTypeController(typeId);
            oldTypeName = types.Type.ToString();
            if (!Page.IsPostBack)
            {
                TxtTypeName.Text = types.Type.ToString();
            }
        }

        protected void DoUpdateType(object sender, EventArgs e)
        {
            string typeName = TxtTypeName.Text.ToString();

            if (DataValidation(typeName) == true)
            {
                UpdatePaymentTypeController.GetUpdatePaymentTypeController(typeId, typeName);
                Response.Redirect("ViewPaymentType.aspx");
            }
        }

        private Boolean DataValidation(string name)
        {
            string errorMessage = "";
            if (UpdatePaymentTypeController.PaymentTypeValidation(name, oldTypeName, out errorMessage) == false)
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