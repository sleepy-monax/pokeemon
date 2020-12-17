using System;
using Model.Battle;
using Model.Creature;

namespace Model.Effets
{
    class Regen : IEffect
    {
        public float Amount { get; set; }

        public Stats Apply(Stats stats)
        {
            stats.Health += Amount;

            return stats;
        }
    }
}