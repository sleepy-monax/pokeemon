using System.Data.SqlClient;

namespace Infrastructure
{
    public class Database
    {
        private static readonly string Connection_String =
            "Server=localhost;Database=Pokeemon;Trusted_Connection=True";

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(Connection_String);
        }
    }
}