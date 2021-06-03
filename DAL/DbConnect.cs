using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace DAL
{
    public class DbConnect
    {
        protected SqlConnection _conn = new SqlConnection(@"Data Source = BOSSMTA; Initial Catalog = QLBH; Integrated Security = True");
        //static string connstr = ConfigurationManager.ConnectionStrings["QLBH"].ToString();
        //protected SqlConnection _conn = new SqlConnection(connstr);
    }
}
