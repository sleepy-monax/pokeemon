using System.Collections.Generic;

namespace Model.UserItems
{
    public interface IUserItemsRepository
    {
        IEnumerable<IUserItems> Query();
        IUserItems Get(int id);
        IUserItems Create(IUserItems userItems);
        bool Delete(int id);
        bool Update(int id, IUserItems userItems);
        IEnumerable<IUserItems> GetByUser(int idUser);
    }
}