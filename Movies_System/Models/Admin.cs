using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Movies_System.BussinessLayer;

namespace Movies_System.Models
{
    public class Admin:Users
    {
        public Admin(string email,string password)
        {
            this.Email = email;
            this.UserPassword = password;
        }
        public Admin()
        {
            this.Name = "";
            this.Email = "";
            this.UserName = "";
            this.UserPassword = "";
            this.PhoneNumber = "";
        }
        public override string SignIn()
        {
            AdminBussinessLayer adminBussiness = new AdminBussinessLayer();
            string message = adminBussiness.CanSignIn(this.Email,this.UserPassword);
            return message;
        }
    }
}