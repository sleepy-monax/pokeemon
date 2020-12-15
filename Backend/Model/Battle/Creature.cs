using System;
using System.Collections.Generic;

namespace Model.Battle
{
    class Creature
    {
        public string Name { get; set; }
        public Stereotype Stereotype { get; set; }
        public int Xp { get; set; }

        public int Level
        {
            get
            {
                var level = 1;
                var xpLeft = Xp;

                do
                {
                    var xpNeeded = Math.Pow(level, 1.1) + 100;
                    xpLeft -= (int)xpNeeded;

                    if (xpLeft > 0)
                    {
                        level++;
                    }
                } while (xpLeft > 0);

                return level;
            }
        }

        public Stats Stats
        {
            get
            {
                var stats = Stereotype.Stats;

                foreach (var statut in Statuts)
                {
                    stats = statut.apply(stats);
                }

                return stats;
            }
        }

        public List<Statut> Statuts { get; set; } = new List<Statut>();
    }
}