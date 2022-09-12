using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using Movies_System.BussinessLayer;

namespace Movies_System
{
    public partial class SignUp : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        [WebMethod]
        public static string CheckUserName(string userName)
        {
            CustomerBussinessLayer customerBussiness = new CustomerBussinessLayer();
            string message = customerBussiness.CheckUserName(userName);
            return message;
        }
        [WebMethod]
        public static string CheckEmail(string email)
        {
            CustomerBussinessLayer customerBussiness = new CustomerBussinessLayer();
            string message = customerBussiness.CheckEmail(email);
            return message;
        }
        [WebMethod]

        public static string AddCustomer(string name,string userName, string phoneNumber, string email, string password)
        {
            CustomerBussinessLayer customerBussiness = new CustomerBussinessLayer();
            string message = customerBussiness.AddCustomerDetail(name, userName, phoneNumber, email, password);
            return message;
;
        }

        protected void Unnamed_Click(object sender, EventArgs e)
        {
            Response.Redirect("SignIn.aspx");
        }
    }
}