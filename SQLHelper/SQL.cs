using System.Data.SqlClient;

namespace SQLHelper
{
    internal class SQL
    {
        private readonly static string connection = @"Data Source=YourServerName;User ID=sa;Password=YourPassword";

        public static void Post(string Query)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connection))
                {
                    using (SqlCommand cmd = new SqlCommand(Query, conn))
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        conn.Close();
                    }
                }
            }
            catch
            {
                return;
            }
        }
    }
}
