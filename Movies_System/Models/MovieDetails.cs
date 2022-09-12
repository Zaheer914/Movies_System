using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Movies_System.Models
{
    public class MovieDetails
    {
        public Movies Movies { get; set; }

        public List<string> Genres { get; set; }
    }
}