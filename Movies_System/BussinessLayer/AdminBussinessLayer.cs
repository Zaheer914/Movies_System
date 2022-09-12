using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Movies_System.DataAccessLayer;
using Movies_System.Models;

namespace Movies_System.BussinessLayer
{
    public class AdminBussinessLayer
    {
        AdminDataAccess adminDataAccess = new AdminDataAccess ();
        public string CanSignIn(string email, string password)
        {
            List<Admin> admin = new List<Admin>();
            admin = adminDataAccess.GetAdminsDetails();

            for (int i = 0; i < admin.Count; i++)
            {
                if (admin[i].Email.ToLower() == email.ToLower().Trim() && admin[i].UserPassword == password)
                {
                    return "Admin";
                }
                if (admin[i].Email.ToLower() == email.ToLower().Trim() && admin[i].UserPassword != password)
                {

                    return "Invalid Password";
                }

            }
            return "Invalid User";
        }
    }
}