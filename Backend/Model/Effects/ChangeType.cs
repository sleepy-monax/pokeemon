using Model.Battle;
using Model.Creature;

namespace Model.Effets
{
    class ChangeType : IEffect
    {
        public Types NewType { get; set; } = Types.Normal;

        public Stats Apply(Stats stats)
        {
            stats.Type = NewType;
            return stats;
        }
    }
}