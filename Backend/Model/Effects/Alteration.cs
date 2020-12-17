using Model.Battle;
using Model.Creature;

namespace Model.Effets
{
    class Alteration : IEffect
    {
        public float Attack { get; set; } = 1;
        public float Defense { get; set; } = 1;
        public float Speed { get; set; } = 1;
        public float Health { get; set; } = 1;

        public Stats Apply(Stats stats)
        {
            stats.Attack *= this.Attack;
            stats.Defense *= this.Defense;
            stats.Speed *= this.Speed;
            stats.Health *= this.Health;

            return stats;
        }
    }
}