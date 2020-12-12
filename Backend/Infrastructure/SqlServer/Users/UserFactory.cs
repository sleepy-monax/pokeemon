using System.Data.SqlClient;
using Model.User;

namespace Infrastructure.SqlServer.Users
{
    public class UserFactory : IFactory<IUser>
    {
        public IUser CreateFromReader(SqlDataReader reader)
        {
            return new User
            {
                Id = reader.GetInt32(reader.GetOrdinal(SqlServerUserRepository.ColId)),
                Administrator = reader.GetBoolean(reader.GetOrdinal(SqlServerUserRepository.ColAdministrator)),
                Email = reader.GetString(reader.GetOrdinal(SqlServerUserRepository.ColEmail)),
                Money = reader.GetInt32(reader.GetOrdinal(SqlServerUserRepository.ColMoney)),
                Password = reader.GetString(reader.GetOrdinal(SqlServerUserRepository.ColPassword)),
                Pseudo = reader.GetString(reader.GetOrdinal(SqlServerUserRepository.ColPseudo))
            };
        }
    }
}