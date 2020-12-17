using Model.Battle;
using Model.Creature;

namespace Model.Effets
{
    class ChangeType : IEffect
    {
        public Types newType { get; set; } = Types.Normal;

        public Stats Apply(Stats stats)
        {
            stats.Type = newType;
            return stats;
        }
    }
}