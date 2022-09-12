using Movies_System.Models;
using Movies_System.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Movies_System.BussinessLayer
{
    public class CustomerBussinessLayer
    {
        CustomerDataAccess customerDataAccess = new CustomerDataAccess();
        public string CanSignIn(string email, string password)
        {
            List<Customers> customer = new List<Customers>();
            customer = customerDataAccess.GetCustomerDetails();

            for (int i = 0; i < customer.Count; i++)
            {
                if (customer[i].Email.ToLower() == email.ToLower().Trim() && customer[i].UserPassword == password.Trim())
                {
                    return "Customer";
                }
                if (customer[i].Email.ToLower() == email.ToLower().Trim() && customer[i].UserPassword != password.Trim())
                {
                    return "Invalid Password";
                }
            }
            return "Invalid User";
        }

        public string AddCustomerDetail(string name, string userName, string phoneNumber, string email, string password)
        
        {
            customerDataAccess.AddCustomerDetail(name, userName, phoneNumber, email, password);
            return "Added";
        }

        public int FindCoustmerId(string email)
        {
            int customerId;
            List<Customers> customer = new List<Customers>();
            customer = customerDataAccess.GetCustomerDetails();

            for (int i = 0; i < customer.Count; i++)
            {
                if (customer[i].Email.ToLower().Trim() == email.ToLower().Trim())
                {
                    customerId = customer[i].CustomerId;
                    return customerId;
                }
            }
            return 0;
        }

        public string CheckUserName(string userName){
            List<Customers> customer = new List<Customers>();
            customer = customerDataAccess.GetCustomerDetails();

            for (int i = 0; i < customer.Count; i++)
            {
                if (customer[i].UserName.ToLower() == userName.ToLower().Trim() )
                {
                    return "Already Taken";
                }
            }
            return "Success";
        }

        public string CheckEmail(string email)
        {
            List<Customers> customer = new List<Customers>();
            customer = customerDataAccess.GetCustomerDetails();

            for (int i = 0; i < customer.Count; i++)
            {
                if (customer[i].Email.ToLower().Trim() == email.ToLower().Trim())
                {
                    return "Already Taken";
                }
            }
            return "Success";
        }

        

    }
}