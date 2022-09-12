using Movies_System.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Movies_System.DataAccessLayer
{
    public class GenresDataAccess
    {
        public List<Genres> GetGenres()
        {
            string connectionStr = System.Configuration.ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionStr))
            {
                List<Genres> genres = new List<Genres>();

                try
                {
                    con.Open();
                    SqlCommand command = new SqlCommand("getGenres", con);
                    command.CommandType = CommandType.StoredProcedure;
                    //get data by using stored procedure
                    SqlDataReader dataReader = command.ExecuteReader();

                    while (dataReader.Read())
                    {
                        Genres genres1 = new Genres();
                        genres1.GenresId = Convert.ToInt32(dataReader["Genres_Id"]);
                        genres1.Name = dataReader["Name"].ToString();


                        genres.Add(genres1);

                    }
                }
                catch (SqlException ex)
                {
                    Console.WriteLine(ex);
                }
                return genres;
            }
        }
    }
}