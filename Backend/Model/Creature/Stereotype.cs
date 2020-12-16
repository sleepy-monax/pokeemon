using System.Collections.Generic;

namespace Model.Battle
{
    public class Stereotype
    {
        public string Name { get; set; } = "";

        public Stats Stats { get; set; } = new Stats();

        public List<Action> Actions { get; set; } = new List<Action>();
    }
}