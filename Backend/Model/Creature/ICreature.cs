using System.Collections.Generic;
using Model.Attacks;
using Model.Effets;
using Model.Shared;

namespace Model.Creature
{
    public interface ICreature : IEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public Stereotype Stereotype { get; set; }

        public int Xp { get; set; }

        public int Level { get; }

        public bool Pickable { get; set; }

        public Stats Stats { get; }

        public bool Alive { get; }

        public bool Defeated { get; }

        public List<IEffect> Effects { get; set; }

        public List<UnLockableAction> AllActions { get; }

        public List<Attack> AvaillableActions { get; }
    }
}