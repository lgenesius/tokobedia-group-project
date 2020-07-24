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
    public partial class ViewPaymentType : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CheckUserAndSession();
            showData();
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

        protected void BtnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx");
        }

        private void showData()
        {
            List<PaymentType> allPaymentType = ViewPaymentTypeController.GetAllPaymentTypeController();
            for(int i = 0; i < allPaymentType.Count; i++)
            {
                TableRow rows = new TableRow();
                paymentTable.Controls.Add(rows);

                TableCell idCell = new TableCell();
                idCell.Controls.Add(new Label()
                {
                    Text = allPaymentType[i].ID.ToString()
                });
                rows.Cells.Add(idCell);

                TableCell nameCell = new TableCell();
                nameCell.Controls.Add(new Label()
                {
                    Text = allPaymentType[i].Type.ToString()
                });
                rows.Cells.Add(nameCell);

                TableCell editBtnCell = new TableCell();
                Button editBtn = new Button()
                {
                    Text = "Update",
                    ID = (i + 1) + "E"
                };
                editBtn.Click += updatePayment;
                editBtnCell.Controls.Add(editBtn);
                rows.Cells.Add(editBtnCell);

                TableCell delBtnCell = new TableCell();
                Button delBtn = new Button()
                {
                    Text = "Delete",
                    ID = (i + 1) + "D"
                };
                delBtn.Click += deletePayment;
                delBtnCell.Controls.Add(delBtn);
                rows.Cells.Add(delBtnCell);
            }
        }

        private void deletePayment(object sender, EventArgs e)
        {
            Button currBtn = (Button)sender;
            int selectedRowIndex = 0;
            if(int.TryParse(currBtn.ID.Substring(0, currBtn.ID.Length - 1), out selectedRowIndex))
            {
                int id = int.Parse(((Label)paymentTable.Rows[selectedRowIndex].Cells[0].Controls[0]).Text);
                string errorMessage = "";
                if (ViewPaymentTypeController.DeletePaymentTypeController(id, out errorMessage) == false)
                {
                    Response.Redirect("ViewPaymentType.aspx");
                }
                else
                {
                    errorMsg.Text = errorMessage;
                }
            }
        }

        private void updatePayment(object sender, EventArgs e)
        {
            Button currBtn = (Button)sender;
            int selectedRowIndex = 0;
            if (int.TryParse(currBtn.ID.Substring(0, currBtn.ID.Length - 1), out selectedRowIndex))
            {
                Response.Redirect("UpdatePaymentType.aspx?id=" + int.Parse(((Label)paymentTable.Rows[selectedRowIndex].Cells[0].Controls[0]).Text) + "");
            }
        }

        protected void BtnInsertPaymentType_Click(object sender, EventArgs e)
        {
            Response.Redirect("InsertPaymentType.aspx");
        }
    }
}