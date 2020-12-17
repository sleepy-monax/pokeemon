using System.Collections.Generic;
using Model.Creature;
using Model.Effets;

namespace Model.Battle
{
    public class Action
    {
        public string Name { get; set; } = "";
        public Types Type { get; set; }
        public string Description { get; set; } = "";

        public int Accuracy { get; set; }
        public int PowerPoint { get; set; }
        public int Probability { get; set; }

        public IEffect? Effect { get; set; }
    }
}