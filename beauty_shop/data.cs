using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace beauty_shop
{
    internal class data
    {
        public static SqlConnection sql = new SqlConnection("Data Source=DESKTOP-MM9TF7P;Initial Catalog=beauty_shop;Integrated Security=True");
        public static admin admin= new admin();
        public static client client= new client();
        public static string table;
        public static int user;
    }
}
