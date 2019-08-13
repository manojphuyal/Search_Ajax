using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebApi.Repository
{
    public class DBConnection
    {


        public SqlConnection con;
        public void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["SiddhiMemorialDB"].ToString();
            con = new SqlConnection(constring);
        }
    }
}