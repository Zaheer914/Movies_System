using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Movies_System.Models;
using Movies_System.DataAccessLayer;

namespace Movies_System.BussinessLayer
{
    public class GenresBussinessLayer
    {
        GenresDataAccess genreslayer = new GenresDataAccess();
        public List<Genres> GetGenres()
        {
            List<Genres> genres = new List<Genres>();
            genres = genreslayer.GetGenres();
            return genres;
        }
    }
}