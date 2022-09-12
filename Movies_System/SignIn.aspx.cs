using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Movies_System.Models;
using Movies_System.BussinessLayer;
namespace Movies_System
{
    public partial class SignIn : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LogIn(object sender, EventArgs e)
        {
            if (this.Roles.Text == "Admin")
            {
                Users users = new Admin(this.Email.Text,this.password.Text);
                string message = users.SignIn();
                if (message == "Admin")
                {
                    Response.Redirect("AdimnPage.aspx");
                }
                else
                {
                    this.InvalidUser.Text = message;
                    this.password.Text = "";
                }
            }

            if (this.Roles.Text == "Customer")
            {
                Users users = new Customers(this.Email.Text, this.password.Text);
                string message = users.SignIn();
                if (message == "Customer")
                {
                    CustomerBussinessLayer customerBussinessLayer = new CustomerBussinessLayer ();
                    Session["cusotmerId"] = customerBussinessLayer.FindCoustmerId(this.Email.Text);
                    int movieId = (int)Session["cusotmerId"];
                    Response.Redirect("CustomerPage.aspx");
                }
                else
                {
                    this.InvalidUser.Text = message;
                    this.password.Text = "";
                }
            }
        }
    }
}