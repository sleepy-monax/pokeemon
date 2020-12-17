using System.Collections.Generic;

namespace Model.Creature
{
    public interface ICreatureRepository
    {
        IEnumerable<ICreature> Query();
        ICreature Get(int id);
        ICreature Create(ICreature creature);
        bool Delete(int id);
        bool Update(int id, ICreature creature);
        IEnumerable<ICreature> GetByUser(int idUser);
    }
}