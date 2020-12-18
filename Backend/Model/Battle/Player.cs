using System;
using System.Linq;
using Model.Messages;

namespace Model.Battle
{
    public class Player
    {
        public Action<Object> OnMessageSent;

        private Creature.Creature[] Creatures { get; set; }

        public int Active { get; set; }

        public Creature.Creature ActiveCreature => Creatures[Active];

        public bool Defeated => Creatures.All(creature => !creature.Alive);

        void SendMessage(Object message)
        {
            OnMessageSent?.Invoke(message);
        }
    }
}

