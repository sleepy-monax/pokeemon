using System.Data.SqlClient;

namespace Infrastructure
{
    public class Database
    {
        private static readonly string Connection_String =
            "Server=127.0.0.1,49765;Database=Pokeemon;Integrated Security=SSPI";

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(Connection_String);
        }
    }
}