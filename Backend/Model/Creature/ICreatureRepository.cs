using System.Collections.Generic;

namespace Model.Creature
{
    public interface ICreatureRepository
    {
        IEnumerable<ICreature> Query();
        bool Create(int id, ICreature creature);
        bool Delete(int id);
        bool Update(int id, ICreature creature);
        IEnumerable<ICreature> GetByUser(int idUser);
    }
}