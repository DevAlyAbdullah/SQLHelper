using System.Data;
using System.Data.SqlClient;

namespace SQLHelper
{
    internal class SQL
    {
        private readonly static string connection = @"Data Source=YourServerName;User ID=YourLoginUserName;Password=YourSQLPassword";

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

        public static string GetSingleValue(string Query)
        {
            try
            {
                DataTable table2 = new DataTable();
                using (SqlConnection conn = new SqlConnection(connection))
                {
                    using (SqlCommand cmd = new SqlCommand(Query, conn))
                    {
                        conn.Open();
                        object Value = cmd.ExecuteScalar();
                        conn.Close();

                        if (Value == null)
                            return string.Empty;
                        else
                            return Value.ToString();
                    }
                }
            }
            catch
            {
                return string.Empty;
            }
        }
    }
}
