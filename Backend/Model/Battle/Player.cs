using System;
using System.Collections.Generic;
using System.Linq;
using Model.Creature;
using Model.Messages;

namespace Model.Battle
{
    public class Player
    {
        private int _active;
        
        public Action<Object> OnMessageSent;
        
        public ICreature [] Creatures { get; set; }
        public List<Item.Item> Items { get; set; }

        public int Active
        {
            get => _active;
            set
            {
                if (value >= 0 && value < Creatures.Length)
                    _active = value;
            }
        }

        public ICreature ActiveCreature => Creatures[Active];

        public bool Defeated => Creatures.All(creature => !creature.Alive);

        public void SendMessage(Object message)
        {
            OnMessageSent?.Invoke(message);
        }
    }
}

