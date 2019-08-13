using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    public class UserModel
    {
        public int Login_ID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Full_Name { get; set; }
        public string Email { get; set; }
        public int Role_ID { get; set; }
        public string Role_Name { get; set; }
        public int Country_ID { get; set; }
        public int State_ID { get; set; }


        public string Country_Name { get; set; }
        public string State_Name { get; set; }
    }
}