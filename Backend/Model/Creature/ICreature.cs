using Model.Shared;

namespace Model.Creature
{
    public interface ICreature : IEntity
    {
        public string Name { get; set; }
        public Stereotype Stereotype { get; set; }
        public int Xp { get; set; }
        public int Level { get; }
        public bool Pickable { get; set; }
    }
}