using System.Collections.Generic;
using System.Data;
using Model.Creature;

namespace Infrastructure.SqlServer.Creatures
{
    public class SqlServerCreatureRepository : ICreatureRepository
    {

        private IFactory<ICreature> _factory = new CreatureFactory();
    
        public static readonly string TableName = "Creatures";
        public static readonly string TableJointure = "UserCreatures";
        public static readonly string ColId = "id";
        public static readonly string ColName = "name";
        public static readonly string ColStereotype = "stereotype";
        public static readonly string ColXp = "xp";
        public static readonly string ColPickable = "pickable";
        public static readonly string ColIdUser = "idUser";
        public static readonly string ColIdCreature = "idCreature";

        public static readonly string ReqQuerry = $"select * from {TableName}";

        public static readonly string ReqGetByUser = $@"select {TableName}.* from {TableName}
        inner join {TableJointure} UM on {TableName}.id = UM.idCreature
            inner join Users U on U.id = UM.idUser
            where U.id = @{ColId}";

        public static readonly string ReqUpdate = $@"
            update {TableName} set
            {ColName} = @{ColName},
            {ColStereotype} = @{ColStereotype},
            {ColXp} = @{ColXp},
            {ColPickable} = @{ColPickable}
            where {ColId} = @{ColId}";

        public static readonly string ReqCreateCreature = $@"insert into {TableName} (stereotype, xp) output inserted.{ColId} 
        values (@{ColStereotype}, @{ColXp})";
        public static readonly string ReqCreateJointure = $@"insert into {TableJointure} ({ColIdUser}, {ColIdCreature}) output inserted.{ColId} 
        values (@{ColIdUser}, @{ColIdCreature})";

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

        public bool Create(int id, ICreature creature)
        {
            using (var connection = Database.GetConnection())
            {
                connection.Open();
                var query = connection.CreateCommand();
                query.CommandText = ReqCreateCreature;

                var isAdd = (int) query.ExecuteScalar();

                if (isAdd != 0)
                {
                    query.CommandText = ReqCreateJointure;
                    return (int) query.ExecuteScalar() != 0;
                }

                return false;
            }
        }

        public bool Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public bool Update(int id, ICreature creature)
        {
            using (var connection = Database.GetConnection())
            {
                connection.Open();
                var query = connection.CreateCommand();
                query.CommandText = ReqUpdate;

                query.Parameters.AddWithValue($"@{ColName}", creature.Name);
                query.Parameters.AddWithValue($"@{ColStereotype}", creature.Stereotype.Name);
                query.Parameters.AddWithValue($"@{ColPickable}", creature.Pickable);
                query.Parameters.AddWithValue($"@{ColXp}", creature.Xp);
                
                query.Parameters.AddWithValue($"@{ColId}", creature.Id);

                return query.ExecuteNonQuery() == 1;
            }
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