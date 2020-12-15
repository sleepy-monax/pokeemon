using System.Collections.Generic;

namespace Model.Battle
{
    class Action
    {
        public string Name { get; set; } = "";
        public Types Type { get; set; }
        public int Power { get; set; }
        public int Accuracy { get; set; }
        public int PowerPoint { get; set; }
        public string Description { get; set; } = "";
        public int Probability { get; set; }

        public Statut? Statut { get; set; }
    }
}