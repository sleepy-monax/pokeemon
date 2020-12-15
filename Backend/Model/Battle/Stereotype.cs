using System.Collections.Generic;

namespace Model.Battle
{
    class Stereotype
    {
        public string Name { get; set; } = "";
        public Types Type { get; set; }
        public Stats Stats { get; set; } = new Stats();
        public List<Action> Actions { get; set; } = new List<Action>();
    }
}