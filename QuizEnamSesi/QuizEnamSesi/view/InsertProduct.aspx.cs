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
    public partial class InsertProduct : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GetUserCookies();
            SetProductData();
        }

        private void SetProductData()
        {
            if (!Page.IsPostBack)
            {
                TxtProductPrice.Text = "0";
                TxtProductStock.Text = "0";
                TxtProductType.Text = "0";
            }


            List<ProductType> allType = InsertProductController.GetAllProductTypeController();

            GridProductType.DataSource = allType;
            GridProductType.DataBind();
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
            if (Int32.Parse(curr.RoleId.ToString()) != 1)
            {
                Response.Redirect("Home.aspx");
            }
        }

        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            string productName = TxtProductName.Text.ToString();
            string productStock = TxtProductStock.Text.ToString();
            string productPrice = TxtProductPrice.Text.ToString();
            string productType = TxtProductType.Text.ToString();

            Boolean isFormatCorrect = ProductValidation(productName, productStock, productPrice, productType);

            if(isFormatCorrect == true)
            {
                InsertProductController.InsertNewProductController(productName, Int32.Parse(productType), Int32.Parse(productStock), Int32.Parse(productPrice));
                LblError.Text = "Data successfully inputted";
            }

        }

        private Boolean ProductValidation(string name, string stock, string price, string typeId)
        {
            string errorMessage = "";
            if(InsertProductController.ProductValidation(name, stock, price, typeId, out errorMessage) == false)
            {
                return HandleWrongFormat(errorMessage);
            }
            return true;
        }

        private bool HandleWrongFormat(string message)
        {
            LblError.Text = message;
            return false;
        }


        protected void BtnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("ViewProduct.aspx");
        }
    }
}