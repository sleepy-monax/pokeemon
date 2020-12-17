using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using Model.UserItems;
using Newtonsoft.Json;

namespace Infrastructure.SqlServer.UserItems
{
    public class SqlServerUserItemsRepository : IUserItemsRepository
    {
        private IFactory<IUserItems> _factory = new UserItemsFactory();
        private static readonly string TableName = "UserItems";
        public static readonly string ColId = "id";
        public static readonly string ColIdUser = "idUser";
        public static readonly string ColNameItem = "nameItem";
        public static readonly string ColQuantity = "quantity";

        private static readonly string ReqQuery = $"select * from {TableName}";
        private static readonly string ReqGet = ReqQuery + $" where {ColId} = @{ColId}";

        private static readonly string ReqCreate = $@"
            insert into {TableName} ({ColIdUser}, {ColNameItem}, {ColQuantity})
            output inserted.{ColId}
            values (@{ColIdUser}, @{ColNameItem}, @{ColQuantity})
        ";

        private static readonly string ReqDelete = $"delete from {TableName} where {ColId} = @{ColId}";

        private static readonly string ReqUpdate = $@"
            update {TableName} set
            {ColIdUser} = @{ColIdUser},
            {ColNameItem} = @{ColNameItem},
            {ColQuantity} = @{ColQuantity}
            where {ColId} = @{ColId}
        ";

        public static DataTable ToDataTable<T>(IList<T> data)
        {
            PropertyDescriptorCollection props =
                TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            for (int i = 0; i < props.Count; i++)
            {
                PropertyDescriptor prop = props[i];
                table.Columns.Add(prop.Name, prop.PropertyType);
            }
            object[] values = new object[props.Count];
            foreach (T item in data)
            {
                for (int i = 0; i < values.Length; i++)
                {
                    values[i] = props[i].GetValue(item);
                }
                table.Rows.Add(values);
            }
            return table;
        }

        public IEnumerable<IUserItems> Query()
        {
            IList<IUserItems> usersItems = new List<IUserItems>();
            using (var connection = Database.GetConnection())
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = ReqQuery;

                var reader = command.ExecuteReader(CommandBehavior.CloseConnection);
                while (reader.Read())
                {
                    usersItems.Add(_factory.CreateFromReader(reader));
                }
            }

            return usersItems;
        }

        public IUserItems Get(int id)
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

        public IUserItems Create(IUserItems userItems)
        {
            using (var connection = Database.GetConnection())
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = ReqCreate;

                command.Parameters.AddWithValue($"@{ColIdUser}", userItems.IdUser);
                command.Parameters.AddWithValue($"@{ColNameItem}", userItems.NameItem);
                command.Parameters.AddWithValue($"@{ColQuantity}", userItems.Quantity);

                userItems.Id = (int)command.ExecuteScalar();
            }

            return userItems;
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

        public bool Update(int id, IUserItems userItems)
        {
            using (var connection = Database.GetConnection())
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = ReqUpdate;

                command.Parameters.AddWithValue($"@{ColIdUser}", userItems.IdUser);
                command.Parameters.AddWithValue($"@{ColNameItem}", userItems.NameItem);
                command.Parameters.AddWithValue($"@{ColQuantity}", userItems.Quantity);

                command.Parameters.AddWithValue($"@{ColId}", id);

                return command.ExecuteNonQuery() == 1;
            }
        }
    }
}