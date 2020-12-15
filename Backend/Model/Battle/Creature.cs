using System;
using System.Collections.Generic;
using System.Linq;

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

        public Stats Stats => Status.Aggregate(Stereotype.Stats, (current, status) => status.Apply(current));

        public List<Statut> Status { get; set; } = new List<Statut>();
    }
}