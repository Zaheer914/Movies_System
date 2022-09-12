using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Movies_System.Models
{
    public class Users
    {
        public string Name { get; set; }
        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string UserName { get; set; }

        public string UserPassword { get; set; }

        public virtual string SignIn() { return ""; }
    }

    
}