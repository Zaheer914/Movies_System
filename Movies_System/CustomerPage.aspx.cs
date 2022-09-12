using Movies_System.BussinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Movies_System
{
    public partial class CustomerPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static string GetMovies()
        {
            MoviesBussinessLayer bussinessLayer1 = new MoviesBussinessLayer();
            JavaScriptSerializer js = new JavaScriptSerializer();
            return js.Serialize(bussinessLayer1.GetMovies());
        }
    }
}