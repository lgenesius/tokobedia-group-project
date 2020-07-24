using QuizEnamSesi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using QuizEnamSesi.Controller;
using System.Text.RegularExpressions;
using QuizEnamSesi.Repository;

namespace QuizEnamSesi.view
{
    public partial class Home : System.Web.UI.Page
    {

        private Model.User userNow;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetUserCookies();
                SetRandomItem();
            }    
        }

        private void GetUserCookies()
        {
            if(Session["user"] == null)
            {

                if(Request.Cookies.Get("user") != null)
                {
                    HttpCookie cookie = Request.Cookies.Get("user");
                    int id = Int32.Parse(cookie.Value);
                    var loggedUser = UserController.GetUserController(id);
                    Session["user"] = loggedUser;
                }
                else
                {
                    GuestUser();
                    return;
                }
            }
            LoggedUser();
        }

        private void GuestUser()
        {
            DivAdminPrivilege.Visible = false;
            BtnLogin.Visible = true;
            BtnRegister.Visible = true;
            BtnLogout.Visible = false;
            BtnForLoggedInUser.Visible = false;
        }

        private void LoggedUser()
        {
            
            userNow = (Model.User)Session["user"];
            Greetings.InnerText = "Hello " + userNow.Name;

            if (userNow.RoleId == 1)
            {
                DivAdminPrivilege.Visible = true;
                BtnViewCart.Visible = false;
            }
            else
            {
                GridRandomItem.Columns[4].Visible = true;
                DivAdminPrivilege.Visible = false;
            }

            BtnForLoggedInUser.Visible = true;
            BtnLogin.Visible = false;
            BtnRegister.Visible = false;
        }

        private void SetRandomItem()
        {
            List<Product> product = HomeController.GetFiveRandomProductController();

            var filtered = product.Select(i => new {
                productId = i.ID,
                ProductName = i.Name,
                ProductPrice = i.Price,
                ProductStock = i.Stock
            });

            if(product.Count > 0)
            {

                GridRandomItem.DataSource = filtered;
                GridRandomItem.DataBind();
            }
        }

        protected void loadgrid2()
        {
            tokobediaModelContainer db = new tokobediaModelContainer();
            List<Product> prod = new List<Product>();
            Random rnd = new Random();
            int value1 = 0;
            int value2 = 0;
            int value3 = 0;
            int value4 = 0;
            int value5 = 0;
            var v = db.Products.OrderByDescending(t => t.ID).First();
            var d = db.Products.OrderBy(c => c.ID).First();
            var e = db.Products.ToList().Count; 
            do
            {
                value1 = rnd.Next(1, e);
            } while (ProductRepository.checkProductId(value1) == null);
            do
            {
                value2 = rnd.Next(1, e);
            } while (ProductRepository.checkProductId(value2) == null || value2 == value1);
            do
            {
                value3 = rnd.Next(1, e);
            } while (ProductRepository.checkProductId(value3) == null || value3 == value2 || value3 == value1);
            do
            {
                value4 = rnd.Next(1, e);
            } while (ProductRepository.checkProductId(value4) == null || value4 == value3 || value4 == value2 || value4 == value1);
            do
            {
                value5 = rnd.Next(1, e);
            } while (ProductRepository.checkProductId(value5) == null || value5 == value4 || value5 == value3 || value5 == value2 || value5 == value1);
            var query = from g in db.Products
                        join m in db.ProductTypes on g.ID equals m.ID
                        where g.ID == value1 || g.ID == value2 || g.ID == value3 || g.ID == value4 || g.ID == value5
                        select new
                        {
                            productId = g.ID,
                            productTypeName = m.Name,
                            ProductName = g.Name,
                            ProductPrice = g.Price,
                            ProductStock = g.Stock
                        };
            GridRandomItem.DataSource = query.ToList();
            GridRandomItem.DataBind();
        }

        protected void LogoutButton(object sender, EventArgs e)
        {
            Session.Abandon();
            HttpCookie cookie = Response.Cookies.Get("user");
            cookie.Expires = DateTime.Now.AddHours(-1);
            Response.Redirect("Home.aspx");
        }

        protected void ViewProduct(object sender, EventArgs e)
        {
            Response.Redirect("ViewProduct.aspx");
        }

        protected void ViewProfile(object sender, EventArgs e)
        {
            Response.Redirect("Profile.aspx");
        }

        protected void ToLogin(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }

        protected void BtnViewUser_Click(object sender, EventArgs e)
        {
            Response.Redirect("ViewUser.aspx");
        }

        protected void BtnInsertProduct_Click(object sender, EventArgs e)
        {
            Response.Redirect("InsertProduct.aspx");
        }

        protected void BtnUpdateProduct_Click(object sender, EventArgs e)
        {
            string id = TxtInputProductId.Text.ToString();

            if (id == String.Empty || Regex.IsMatch(id, @"^[a-zA-Z]+$") == true || HomeController.GetProductController(Int32.Parse(id)) == null)
            {
                LblErrorProduct.Text = "Enter the right ID!";
                return;
            }

            Response.Redirect("UpdateProduct.aspx?productId=" + Int32.Parse(id));
        }

        protected void BtnViewProductType_Click(object sender, EventArgs e)
        {
            Response.Redirect("ViewProductType.aspx");
        }

        protected void BtnInsertProductType_Click(object sender, EventArgs e)
        {
            Response.Redirect("InsertProductType.aspx");
        }

        protected void BtnUpdateProductType_Click(object sender, EventArgs e)
        {
            string id = TxtInputProductTypeId.Text.ToString();

            if (id == String.Empty || Regex.IsMatch(id, @"^[a-zA-Z]+$") == true || HomeController.GetProductTypeController(Int32.Parse(id)) == null)
            {
                LblErrorProductType.Text = "Enter the right ID!";
                return;
            }

            Response.Redirect("UpdateProductType.aspx?productTypeId=" + Int32.Parse(id));
        }

        protected void BtnViewPaymentType_Click(object sender, EventArgs e)
        {
            Response.Redirect("ViewPaymentType.aspx");
        }

        protected void ToRegister(object sender, EventArgs e)
        {
            Response.Redirect("Register.aspx");
        }

        protected void ViewCart(object sender, EventArgs e)
        {
            Response.Redirect("ViewCart.aspx");
        }

        protected void btnTransHis_Click(object sender, EventArgs e)
        {
            Response.Redirect("TransactionHistory.aspx");
        }

        protected void BtnAddToCart_Click(object product, EventArgs e)
        {
            int productId = Int32.Parse((product as LinkButton).CommandArgument);
            Response.Redirect("AddToCartPage.aspx?productId=" + productId);
        }
    }
}