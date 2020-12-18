using Model.Effets;

namespace Model.Attacks
{
    public class Attack
    {
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";

        public int Accuracy { get; set; }
        public int PowerPoint { get; set; }
        public int Probability { get; set; }

        public IEffect? Effect { get; set; }

        public Attack Clone()
        {
            return (Attack)this.MemberwiseClone();
        }
    }
}