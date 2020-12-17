using System.Collections.Generic;
using Model.Battle;

namespace Model.Creature
{
    public class Stereotype
    {
        public string Name { get; set; } = "";

        public Stats Stats { get; set; } = new Stats();

        public List<Action> Actions { get; set; } = new List<Action>();
    }
}