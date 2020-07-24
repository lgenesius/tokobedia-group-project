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
    public partial class ViewProduct : System.Web.UI.Page
    {

        private Model.User userNow;

        protected void Page_Load(object sender, EventArgs e)
        {
            BtnForAdmin.Visible = false;
            CheckSessionAndUserType();
            loadgrid();
        }

        private void CheckSessionAndUserType()
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
                    return;
                }
            }
            ShowBtnAdmin();
        }

        private void ShowAllItem()
        {
            List<Product> product = ViewProductController.GetAllProductController();

            var filtered = product.Select(i => new {
                Id = i.ID,
                Name = i.Name,
                ProductType = i.ProductType.Name,
                Stock = i.Stock,
                Price = i.Price
            });

            if (filtered.Count() > 0)
            {
                GridAllItem.DataSource = filtered;
                GridAllItem.DataBind();
            }
        }

        protected void loadgrid()
        {
            tokobediaModelContainer db = new tokobediaModelContainer();
            var query = from g in db.Products
                        join m in db.ProductTypes on g.ProductTypeID equals m.ID
                        select new
                        {
                            Id = g.ID,
                            Name = g.Name,
                            ProductType = m.Name,
                            Stock = g.Stock,
                            Price = g.Price
                        };
            GridAllItem.DataSource = query.ToList();
            GridAllItem.DataBind();
        }

        private void ShowBtnAdmin()
        {
            userNow = (Model.User)Session["user"];

            if (Int32.Parse(userNow.RoleId.ToString()) == 1)
            {
                BtnForAdmin.Visible = true;
                GridAllItem.Columns[5].Visible = true;
            }
            else
            {
                BtnForAdmin.Visible = false;
                GridAllItem.Columns[5].Visible = false;
                GridAllItem.Columns[6].Visible = true;
            }
        }

        private void GoToInsertProduct()
        {
            Response.Redirect("InsertProduct.aspx");
        }

        private void GoToUpdateProduct()
        {
            Response.Redirect("UpdateProduct.aspx");
        }

        protected void BtnUpdateProduct_Click(object product, EventArgs e)
        {
            int productId = Int32.Parse((product as LinkButton).CommandArgument);
            Response.Redirect("UpdateProduct.aspx?productId="+ productId);
        }

        protected void BtnDeleteProduct_Click(object product, EventArgs e)
        {
            int productId = Int32.Parse((product as LinkButton).CommandArgument);
            string errorMessage = "";
            if(ViewProductController.DeleteValidation(productId, out errorMessage) == true)
            {
                Response.Redirect("ViewProduct.aspx");
            }
            else
            {
                LblError.Text = errorMessage;
            }
        }

        protected void BtnAddToCart_Click(object product, EventArgs e)
        {
            int productId = Int32.Parse((product as LinkButton).CommandArgument);
            Response.Redirect("AddToCartPage.aspx?productId=" + productId);
        }

        protected void BtnToHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx");
        }

        protected void BtnInsertProduct_Click(object sender, EventArgs e)
        {
            Response.Redirect("InsertProduct.aspx");
        }
    }
}