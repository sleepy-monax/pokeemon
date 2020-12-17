using Model.Battle;

namespace Model.Creature
{
    public struct Stats
    {
        public Types Type { get; set; }

        public float Attack { get; set; }
        public float Defense { get; set; }
        public float Speed { get; set; }
        public float Health { get; set; }
    }
}