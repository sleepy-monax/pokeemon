using System;
using System.Collections.Generic;
using System.Data;
using Model.User;
using Model.Utils;

namespace Infrastructure.SqlServer.Users
{
    public class SqlServerUserRepository : IUserRepository
    {
        
        private  IFactory<IUser> _factory = new UserFactory();
        private static readonly string TableName = "Users";
        public static readonly string ColId = "id";
        public static readonly string ColAdministrator = "administrator";
        public static readonly string ColPseudo = "pseudo";
        public static readonly string ColEmail = "email";
        public static readonly string ColPassword = "password";
        public static readonly string ColMoney = "money";

        private static readonly string ReqQuery = $"select * from {TableName}";
        private static readonly string ReqGet = ReqQuery + $" where {ColId} = @{ColId}";

        private static readonly string ReqCreate = $@"
            insert into {TableName} ({ColAdministrator}, {ColPseudo}, {ColEmail}, {ColPassword}, {ColMoney})
            output inserted.{ColId}
            values (@{ColAdministrator}, @{ColPseudo}, @{ColEmail}, @{ColPassword}, @{ColMoney})
        ";

        private static readonly string ReqExist =  ReqQuery + $" where {ColPseudo} = @{ColPseudo} or " +
                                                   $"{ColEmail} = @{ColEmail}";

        private static readonly string ReqDelete = $"delete from {TableName} where {ColId} = @{ColId}";

        private static readonly string ReqUpdate = $@"
            update {TableName} set
            {ColPseudo} = @{ColPseudo},
            {ColEmail} = @{ColEmail},
            {ColPassword} = @{ColPassword},
            {ColMoney} = @{ColMoney}
            where {ColId} = @{ColId}
        ";

        public IEnumerable<IUser> Query()
        {
            IList<IUser> users = new List<IUser>();
            using (var connection = Database.GetConnection())
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = ReqQuery;

                var reader = command.ExecuteReader(CommandBehavior.CloseConnection);
                while (reader.Read())
                {
                    users.Add(_factory.CreateFromReader(reader));
                }
            }

            return users;
        }

        public IUser Get(int id)
        {
            using (var connection = Database.GetConnection())
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = ReqGet;

                command.Parameters.AddWithValue($"@{ColId}", id);

                var reader = command.ExecuteReader(CommandBehavior.CloseConnection);
                return reader.Read() ? _factory.CreateFromReader(reader) : null;
            }
        }

        private IUser UserExist(IUser user)
        {
            using (var connection = Database.GetConnection())
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = ReqExist;

                command.Parameters.AddWithValue($"@{ColPseudo}", user.Pseudo);
                command.Parameters.AddWithValue($"@{ColEmail}", user.Email);

                var reader = command.ExecuteReader(CommandBehavior.CloseConnection);
                return reader.Read() ? _factory.CreateFromReader(reader) : null;
            }
        }

        public IUser Create(IUser user)
        {
            var exist = UserExist(user);
            if (exist != null)
                return new User(exist.Pseudo, exist.Email);

            CorrectValue(user);
            user = new User((User) user);
            using (var connection = Database.GetConnection())
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = ReqCreate;
                
                command.Parameters.AddWithValue($"@{ColAdministrator}", user.Administrator);
                command.Parameters.AddWithValue($"@{ColEmail}", user.Email);
                command.Parameters.AddWithValue($"@{ColPseudo}", user.Pseudo);
                command.Parameters.AddWithValue($"@{ColMoney}", user.Money);

                var hash = BCrypt.Net.BCrypt.HashPassword(user.Password);
                command.Parameters.AddWithValue($"@{ColPassword}", hash);

                user.Id = (int) command.ExecuteScalar();
            }

            return user;
        }

        private void CorrectValue(IUser user)
        {
            user.Email = SQLServer.MySQLEscape(user.Email);
            user.Password = SQLServer.MySQLEscape(user.Password);
            user.Pseudo = SQLServer.MySQLEscape(user.Pseudo);
        }

        public bool Delete(int id)
        {
            using (var connection = Database.GetConnection())
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = ReqDelete;

                command.Parameters.AddWithValue($"@{ColId}", id);

                return command.ExecuteNonQuery() == 1;
            }
        }

        public bool Update(int id, IUser user)
        {
            using (var connection = Database.GetConnection())
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = ReqUpdate;

                command.Parameters.AddWithValue($"@{ColPseudo}", user.Pseudo);
                command.Parameters.AddWithValue($"@{ColPassword}", user.Password);
                command.Parameters.AddWithValue($"@{ColEmail}", user.Email);
                command.Parameters.AddWithValue($"@{ColMoney}", user.Money);
                
                command.Parameters.AddWithValue($"@{ColId}", id);

                return command.ExecuteNonQuery() == 1;

            }
        }
    }
}
