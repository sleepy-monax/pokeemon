using System.Data.SqlClient;
using Model.UserItems;

namespace Infrastructure.SqlServer.UserItems
{
    public class UserItemsFactory : IFactory<IUserItems>
    {
        public IUserItems CreateFromReader(SqlDataReader reader)
        {
            return new UserItem
            {
                Id = reader.GetInt32(reader.GetOrdinal(SqlServerUserItemsRepository.ColId)),
                IdUser = reader.GetInt32(reader.GetOrdinal(SqlServerUserItemsRepository.ColIdUser)),
                NameItem = reader.GetString(reader.GetOrdinal(SqlServerUserItemsRepository.ColNameItem)),
                Quantity = reader.GetInt32(reader.GetOrdinal(SqlServerUserItemsRepository.ColQuantity))
            };
        }
    }
}