using System.Configuration;
using System.Data.SqlClient;

namespace PepinoHealth.Common
{
    internal class DBConnection
    {
        internal SqlConnection AccessToPepinoHealthApp()
        {
            SqlConnection SqlConnection = null;

            try
            {
                SqlConnection = new SqlConnection();
                SqlConnection.ConnectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ToString();
            }
            catch (SqlException Ex)
            {

            }

            return SqlConnection;
        }
    }
}