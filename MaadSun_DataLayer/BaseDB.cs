using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace MaadSun_DataLayer
{
    public class BaseDB
    {
        public SqlConnection ProjectConnection;
        public BaseDB()
        {
            try
            {
                ProjectConnection = new SqlConnection(@"Data Source=.; Database = MaadSun_DataBase; Trusted_Connection=True");
            }
            catch (Exception ex)
            {
                throw new Exception("SqlConnection");
            }
        }
    }
}
