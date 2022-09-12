using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Movies_System.Models;
using Movies_System.DataAccessLayer;

namespace Movies_System.BussinessLayer
{   
    public class MoviesBussinessLayer
    {   
        MoviesDataAccessLayer moviesDataAccessLayer = new MoviesDataAccessLayer();
        public string AddMovies(string movieName, int moviePrice, string[] genres)
        {
            int movieId;
            movieId = moviesDataAccessLayer.AddMovies(movieName, moviePrice);
            for (int i = 0; i < genres.Length; i++)
            {
                int genresId = Convert.ToInt32(genres[i]);
                moviesDataAccessLayer.AddGenresInMovies(genresId, movieId);
            }
            return "SuccessFully Added Movies";
        }

        public string IsExist(string movieName) 
        {
            int movieExistence;
            movieExistence = moviesDataAccessLayer.IsMovieExist(movieName);
            if (movieExistence != 0)
            {
                return "Already Exist";
            }
            return "Success";
        }

        public List<MovieDetails> GetMovies()
        {
            return moviesDataAccessLayer.GetMoviesWithDetails();

        }

        public void DeleteMovies(int data)
        {
            moviesDataAccessLayer.DeleteMovies(data);
        }
    }

}