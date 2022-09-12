using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Movies_System.Models;

namespace Movies_System.DataAccessLayer
{
    public class MoviesDataAccessLayer
    {
        public int AddMovies(string name, int price)
        {
            int movieId;
            string connectionStr = System.Configuration.ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionStr))
            {
                try
                {
                    con.Open();
                    SqlCommand command = new SqlCommand("addMovies", con);
                    command.Parameters.AddWithValue("@Name", SqlDbType.Int).Value = name;
                    command.Parameters.AddWithValue("@Price", SqlDbType.Int).Value = price;

                    command.CommandType = CommandType.StoredProcedure;
                    SqlDataReader dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        movieId = Convert.ToInt32(dataReader["Movie_Id"]);
                        return movieId;
                    }

                }
                catch (SqlException ex)
                {
                    Console.WriteLine(ex);
                }
                con.Close();
            }
            return 0;
        }


        public void AddGenresInMovies(int genresId, int movieId)
        {
            string connectionStr = System.Configuration.ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionStr))
            {
                try
                {
                    con.Open();
                    SqlCommand command = new SqlCommand("addGenresInMovies", con);
                    command.Parameters.AddWithValue("@movie_Id", SqlDbType.Int).Value = movieId;
                    command.Parameters.AddWithValue("@genres_Id", SqlDbType.Int).Value = genresId;
                    command.CommandType = CommandType.StoredProcedure;
                    command.ExecuteNonQuery();

                }
                
                catch (SqlException ex)
                {
                    Console.WriteLine(ex);
                }
                con.Close();
            }
        }

        public int IsMovieExist(string movieName)
        {
            int movieCount;
            string connectionStr = System.Configuration.ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionStr))
            {
                try
                {
                    con.Open();
                    SqlCommand command = new SqlCommand("IsMovieExist", con);
                    command.Parameters.AddWithValue("@movieName", SqlDbType.Int).Value = movieName;
                    command.CommandType = CommandType.StoredProcedure;
                    //get data by using stored procedure
                    SqlDataReader dataReader = command.ExecuteReader();

                    while (dataReader.Read())
                    {
                        movieCount = Convert.ToInt32(dataReader["Count"]);
                        return movieCount;
                    }

                }
                catch (SqlException ex)
                {
                    Console.WriteLine(ex);
                }
                con.Close();
                return 0;
            }
        }


        public List<Movies> GetMovies()
        {
            List<Movies> movies = new List<Movies>();

            string connectionStr = System.Configuration.ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionStr))
            {
                try
                {
                    con.Open();
                    SqlCommand command = new SqlCommand("getMovies", con);
                    command.CommandType = CommandType.StoredProcedure;
                    //get data by using stored procedure
                    SqlDataReader dataReader = command.ExecuteReader();

                    while (dataReader.Read())
                    {
                        Movies movies1 = new Movies();
                        movies1.MovieId = Convert.ToInt32(dataReader["Movie_Id"]);
                        movies1.MovieName = dataReader["Name"].ToString();
                        movies1.MoviePrice = Convert.ToInt32(dataReader["Price"]);

                        movies.Add(movies1);
                    }
                    dataReader.Close();
                }
                catch (SqlException ex)
                {
                    Console.WriteLine(ex);
                }
                con.Close();
                return movies;
            } 
        }

        public List<MovieDetails> GetMoviesWithDetails() { 
            List<MovieDetails> movieDetails = new List<MovieDetails>();
            List<Movies> movies = new List<Movies>();
            movies = GetMovies();
            string connectionStr = System.Configuration.ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionStr))
            {
                try
                {
                    con.Open();
                    
                    for (int i = 0; i < movies.Count; i++)
                    {
                        SqlCommand com = new SqlCommand("getMoviesGenres", con);
                        com.Parameters.AddWithValue("@movieId", SqlDbType.Int).Value = movies[i].MovieId;
                        com.CommandType = CommandType.StoredProcedure;
                        
                        Movies movies2 = new Movies();
                        movies2.MovieId = movies[i].MovieId;
                        movies2.MovieName = movies[i].MovieName;
                        movies2.MoviePrice = movies[i].MoviePrice;

                        MovieDetails details = new MovieDetails();
                        details.Movies = movies2;
                        List<string> list = new List<string>();
                        SqlDataReader dr = com.ExecuteReader();
                        while (dr.Read())
                        {
                            list.Add(dr["Name"].ToString());
                        }
                        dr.Close();
                        details.Genres = list;

                        movieDetails.Add(details);
                    }
                }
                catch (SqlException ex)
                {
                    Console.WriteLine(ex);
                }
                con.Close();
                return movieDetails;
            }
        }

        public void DeleteMovies(int movieId)
        {
            string connectionStr = System.Configuration.ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionStr))
            {
                try
                {
                    con.Open();
                    SqlCommand command = new SqlCommand("deleteMovies", con);
                    command.Parameters.AddWithValue("@movieId", SqlDbType.Int).Value = movieId;
                    command.CommandType = CommandType.StoredProcedure;
                    command.ExecuteNonQuery();

                }

                catch (SqlException ex)
                {
                    Console.WriteLine(ex);
                }
                con.Close();
            }
        }
    }
}