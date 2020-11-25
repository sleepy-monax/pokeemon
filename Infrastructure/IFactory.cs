using System.Data.SqlClient;

namespace Infrastructure
{
    public interface IFactory<out T>
    {
        T CreateFromReader(SqlDataReader reader);
    }
}