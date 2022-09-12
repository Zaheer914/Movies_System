using Movies_System.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Movies_System.DataAccessLayer
{
    public class AdminDataAccess
    {
        public List<Admin> GetAdminsDetails()
        {
            string connectionStr = System.Configuration.ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionStr))
            {
                List<Admin> admin = new List<Admin>();

                try
                {
                    con.Open();
                    SqlCommand command = new SqlCommand("getUsersDetails", con);
                    command.Parameters.AddWithValue("@role", SqlDbType.Int).Value = "Admin";
                    command.CommandType = CommandType.StoredProcedure;
                    //get data by using stored procedure
                    SqlDataReader dataReader = command.ExecuteReader();

                    while (dataReader.Read())
                    {
                        Admin admin1 = new Admin();
                        admin1.Name = dataReader["Name"].ToString();
                        admin1.Email = dataReader["Email"].ToString();
                        admin1.PhoneNumber = dataReader["PhoneNumber"].ToString();
                        admin1.UserName = dataReader["UserName"].ToString();
                        admin1.UserPassword = dataReader["UserPassword"].ToString();

                        admin.Add(admin1);

                    }


                }
                catch (SqlException ex)
                {
                    Console.WriteLine(ex);
                }
                return admin;
            }
        }
    }
}