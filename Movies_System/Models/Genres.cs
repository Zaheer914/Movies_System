using System;
using System.Collections.Generic;
using Movies_System.BussinessLayer;

namespace Movies_System.Models
{
    public class Genres
    {
        public int GenresId { get; set; }
        public string Name { get; set; }

        public List<Genres> GetGenres()
        {
            GenresBussinessLayer bussinessLayer = new GenresBussinessLayer();
            List<Genres> genres = new List<Genres>();
            genres = bussinessLayer.GetGenres();
            return genres;
        }
    }
}