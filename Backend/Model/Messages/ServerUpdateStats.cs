using Anotations;
using Model.Creature;

namespace Model.Messages
{
    [MessageType("battle-stats-update")]
    public class ServerUpdateStats
    {
        public int CreatureId { get; set; }
        public Stats Stats { get; set; }
    }
}