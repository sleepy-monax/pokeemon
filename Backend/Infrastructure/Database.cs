using System;
using System.Data.SqlClient;

namespace Infrastructure
{
    public class Database
    {
        private static string ConnectionString
        {
            get
            {
                var address = Environment.GetEnvironmentVariable("PK_DATABASE_ADDRESS") ?? "localhost";
                var database = Environment.GetEnvironmentVariable("PK_DATABASE_DATABASE") ?? "Pokeemon";
                var username = Environment.GetEnvironmentVariable("PK_DATABASE_USERNAME");
                var password = Environment.GetEnvironmentVariable("PK_DATABASE_PASSWORD");

                if (username is null || password is null)
                {
                    return $"Server={address};Database={database};Trusted_Connection=True";
                }

                return $"Server={address};Database={database};User Id={username};Password={password};";
            }
        }

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(ConnectionString);
        }
    }
}