using Movies_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Movies_System.DataAccessLayer;

namespace Movies_System.BussinessLayer
{
    public class GetUsersDetail
    {
        AdminDataAccess adminDataAccess = new AdminDataAccess();
        CustomerDataAccess customerDataAccess = new CustomerDataAccess();
        public string GetUserDetail(string email, string password, string role)
        {   
            if (role == "Admin")
            {
                List<Admin> admin = new List<Admin>();
                admin = adminDataAccess.GetAdminsDetails();

                for (int i = 0; i < admin.Count; i++)
                {
                    if (admin[i].Email.ToLower() == email.ToLower().Trim() && admin[i].UserPassword == password.Trim())
                    {
                        return "Admin";
                    }
                    if (admin[i].Email.ToLower() == email.ToLower().Trim() && admin[i].UserPassword != password.Trim())
                    {

                        return "Invalid Password";
                    }

                }

            }

            if (role == "Customer")
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
            }

            return "Invalid User";

        }
    }
}