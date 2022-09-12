using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Movies_System.Models;
namespace Movies_System.DataAccessLayer
{
    public class CustomerDataAccess
    {
        public List<Customers> GetCustomerDetails()
        {
            string connectionStr = System.Configuration.ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionStr))
            {
                List<Customers> customers = new List<Customers>();

                try
                {
                    con.Open();
                    SqlCommand command = new SqlCommand("getUsersDetails", con);
                    command.Parameters.AddWithValue("@role", SqlDbType.Int).Value = "Customer";
                    command.CommandType = CommandType.StoredProcedure;
                    //get data by using stored procedure
                    SqlDataReader dataReader = command.ExecuteReader();

                    while (dataReader.Read())
                    {
                        Customers customer = new Customers();
                        customer.CustomerId = Convert.ToInt32(dataReader["Users_Id"]);
                        customer.Name = dataReader["Name"].ToString();
                        customer.Email = dataReader["Email"].ToString();
                        customer.PhoneNumber = dataReader["PhoneNumber"].ToString();
                        customer.UserName = dataReader["UserName"].ToString();
                        customer.UserPassword = dataReader["UserPassword"].ToString();

                        customers.Add(customer);

                    }


                }
                catch (SqlException ex)
                {
                    Console.WriteLine(ex);
                }
                return customers;
            }
        }

        public void AddCustomerDetail(string name, string userName, string phoneNumber, string email, string password)
        {
            string connectionStr = System.Configuration.ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionStr))
            {

                try
                {
                    con.Open();
                    SqlCommand command = new SqlCommand("addUsersDetails", con);
                    command.Parameters.AddWithValue("@Name", SqlDbType.Int).Value = name;
                    command.Parameters.AddWithValue("@UserName", SqlDbType.Int).Value = userName;
                    command.Parameters.AddWithValue("@PhoneNumber", SqlDbType.Int).Value = phoneNumber;
                    command.Parameters.AddWithValue("@Email", SqlDbType.Int).Value = email;
                    command.Parameters.AddWithValue("@role", SqlDbType.Int).Value = "Customer";
                    command.Parameters.AddWithValue("@UserPassword", SqlDbType.Int).Value = password;
                    command.CommandType = CommandType.StoredProcedure;
                    //get data by using stored procedure
                    command.ExecuteNonQuery();


                }
                catch (SqlException ex)
                {
                    Console.WriteLine(ex);
                }

            }
        }

        public void AddToCart(int customerId, int movieId)
        {
            string connectionStr = System.Configuration.ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionStr))
            {

                try
                {
                    con.Open();
                    SqlCommand command = new SqlCommand("addToCart", con);
                    command.Parameters.AddWithValue("@CustomerId", SqlDbType.Int).Value = customerId;
                    command.Parameters.AddWithValue("@MovieId", SqlDbType.Int).Value = movieId;
                    command.CommandType = CommandType.StoredProcedure;
                    //get data by using stored procedure
                    command.ExecuteNonQuery();


                }
                catch (SqlException ex)
                {
                    Console.WriteLine(ex);
                }

            }
        }
    }
}