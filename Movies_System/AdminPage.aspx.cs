using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using Movies_System.Models;
using Movies_System.BussinessLayer;
using System.Web.Script.Serialization;

namespace Movies_System
{
    public partial class AdminPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Genres genres1 = new Genres();
                List<Genres> genres = new List<Genres>();
                genres = genres1.GetGenres();
                this.genres.DataSource = genres;
                this.genres.DataBind();
            }
            

        }
        [WebMethod]

        public static string AddMovies(string movieName, int moviePrice, string[] genres)
        {
            MoviesBussinessLayer bussinessLayer1 = new MoviesBussinessLayer();
            string message = bussinessLayer1.IsExist(movieName);
            if (message != "Already Exist")
            {
                bussinessLayer1.AddMovies(movieName, moviePrice, genres);
                return "SuccessFully Added";
            }
            
                return "Already Exist";
        }

        [WebMethod]
        public static string GetMovies()
        {
            MoviesBussinessLayer bussinessLayer1 = new MoviesBussinessLayer();
            JavaScriptSerializer js = new JavaScriptSerializer();
            return js.Serialize(bussinessLayer1.GetMovies());
        }

        [WebMethod]

        public static void DeleteMovies(int data)
        {
            MoviesBussinessLayer bussinessLayer1 = new MoviesBussinessLayer();
            bussinessLayer1.DeleteMovies(data);
        }
    }
}