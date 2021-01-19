using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using Infrastructure.Json;
using Model.Battle;
using Model.Creature;
using Model.Effets;

namespace Infrastructure.SqlServer.Creatures
{
    public class CreatureFactory : IFactory<ICreature>
    {
        public ICreature CreateFromReader(SqlDataReader reader)
        {
            string name = reader.GetString(reader.GetOrdinal(SqlServerCreatureRepository.ColStereotype));

            Creature creature = new Creature
            {
                Id = reader.GetInt32(reader.GetOrdinal(SqlServerCreatureRepository.ColId)),
                Name = reader.IsDBNull(reader.GetOrdinal(SqlServerCreatureRepository.ColName))
                    ? name
                    : reader.GetString(reader.GetOrdinal(SqlServerCreatureRepository.ColName)),
                Xp = reader.GetInt32(reader.GetOrdinal(SqlServerCreatureRepository.ColXp)),
                Pickable = reader.GetBoolean(reader.GetOrdinal(SqlServerCreatureRepository.ColPickable)),
                Stereotype = JsonStereotypes.GetByName(name)
            };


            return creature;
        }
    }
}