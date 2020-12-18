using System;
using System.Linq;
using Model.Creature;

namespace Model.Battle
{
    public class Player
    {
        private Creature.Creature[] Creatures { get; set; }

        public int Active { get; set; }

        public Creature.Creature ActiveCreature => Creatures[Active];

        public bool Defeated => Creatures.All(creature => !creature.Alive);
    }
}
