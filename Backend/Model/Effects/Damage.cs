using System;
using Model.Battle;
using Newtonsoft.Json;

namespace Model.Effets
{
    class Damage : IEffect
    {
        public float Amount { get; set; }

        [JsonProperty(PropertyName = "damage")]
        public Types Type { get; set; } = Types.Normal;

        public Stats Apply(Stats stats)
        {
            stats.Health -= Amount;
            stats.Health = Math.Max(stats.Health, 0);

            return stats;
        }
    }
}