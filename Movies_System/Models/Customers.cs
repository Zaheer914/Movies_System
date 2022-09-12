using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Movies_System.BussinessLayer;

namespace Movies_System.Models
{
    public class Customers:Users
    {
        public int CustomerId { get; set; }

        public Customers() 
        {
            this.Name = "";
            this.Email = "";
            this.UserName = "";
            this.UserPassword = "";
            this.PhoneNumber = "";
            this.CustomerId = 0;
        }
        public Customers(string email,string password)
        {
            this.Email = email;
            this.UserPassword = password;
        }
        public Customers(string name,string userName,string password,string email,string phoneNumber)
        {
            this.Name = name;
            this.UserPassword=password;
            this.PhoneNumber=phoneNumber;
            this.UserName= userName;
            this.Email=email;
        }

        public override string SignIn()
        {
            CustomerBussinessLayer customerBussinessLayer = new CustomerBussinessLayer();
            string message = customerBussinessLayer.CanSignIn(this.Email, this.UserPassword);
            return message;
        }

        public string SignUp()
        {
            CustomerBussinessLayer customerBussinessLayer = new CustomerBussinessLayer();
            string message = customerBussinessLayer.AddCustomerDetail(this.Name,this.UserName,this.PhoneNumber,this.Email,this.UserPassword);
            return message;
        }
    }
}