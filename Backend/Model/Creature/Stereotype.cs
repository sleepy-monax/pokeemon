using System.Collections.Generic;
using Model.Attacks;
using Model.Battle;

namespace Model.Creature
{
    public class Stereotype
    {
        public string Name { get; set; } = "";

        public Stats Stats { get; set; } = new Stats();

        public List<UnLockableAction> Actions { get; set; } = new List<UnLockableAction>();
    }
}