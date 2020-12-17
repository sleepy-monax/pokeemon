using System.Collections.Generic;
using System.Data;
using Model.Creature;

namespace Infrastructure.SqlServer.Creatures
{
    public class SqlServerCreatureRepository : ICreatureRepository
    {

        private IFactory<ICreature> _factory = new CreatureFactory();
        
        public static readonly string TableName = "Monsters";
        public static readonly string TableJointure = "UserMonsters";
        public static readonly string ColId = "id";
        public static readonly string ColName = "name";
        public static readonly string ColStereotype = "stereotype";
        public static readonly string ColXp = "xp";
        public static readonly string ColPickable = "pickable";

        public static readonly string ReqQuerry = $"select * from {TableName}";

        public static readonly string ReqGetByUser = $@"select Monsters.* from Monsters
        inner join UserMonsters UM on Monsters.id = UM.idMonster
            inner join Users U on U.id = UM.idUser
            where U.id = @{ColId}";

        public IEnumerable<ICreature> Query()
        {
            IList<ICreature> creatures = new List<ICreature>();
            using (var connection = Database.GetConnection())
            {
                connection.Open();
                var query = connection.CreateCommand();
                query.CommandText = ReqQuerry;

                var reader = query.ExecuteReader(CommandBehavior.CloseConnection);
                while (reader.Read())
                {
                    creatures.Add(_factory.CreateFromReader(reader));
                }
            }

            return creatures;
        }

        public ICreature Get(int id)
        {
            throw new System.NotImplementedException();
        }

        public ICreature Create(ICreature creature)
        {
            throw new System.NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public bool Update(int id, ICreature creature)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<ICreature> GetByUser(int idUser)
        {
            IList<ICreature> creatures = new List<ICreature>();
            using (var connection = Database.GetConnection())
            {
                connection.Open();
                var query = connection.CreateCommand();
                query.CommandText = ReqGetByUser;

                query.Parameters.AddWithValue($"@{ColId}", idUser);

                var reader = query.ExecuteReader(CommandBehavior.CloseConnection);
                while (reader.Read())
                {
                    creatures.Add(_factory.CreateFromReader(reader));
                }
            }

            return creatures;
        }
    }
}