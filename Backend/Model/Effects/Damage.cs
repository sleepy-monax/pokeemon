using System;
using Model.Battle;

namespace Model.Effets
{
    class Damage : IEffect
    {
        public float Amount { get; set; }

        public Stats Apply(Stats stats)
        {
            stats.Health -= Amount;
            stats.Health = Math.Max(stats.Health, 0);

            return stats;
        }
    }
}