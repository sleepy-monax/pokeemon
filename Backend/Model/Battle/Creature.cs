using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Model.Effets;

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

        public Stats Stats => Effects.Aggregate(Stereotype.Stats, (current, effect) => effect.Apply(current));

        public bool Alive => Stats.Health > 0;

        public ObservableCollection<IEffect> Effects { get; set; } = new ObservableCollection<IEffect>();

        public List<UnLockableAction> AllActions { get; set; } = new List<UnLockableAction>();

        public List<Action> AvaillableActions => AllActions
            .FindAll(unlockable => unlockable.Level <= Level)
            .Select(unlockable => unlockable.Action)
            .ToList();
    }
}