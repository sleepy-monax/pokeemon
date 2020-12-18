using System;
using Model.Creature;

namespace Model.Battle
{
    public class Player
    {
        private ICreature[] _creatures;
        private int _active = 0;

        public ICreature ActiveCreature => _creatures[_active];

        public Player()
        {
        }
    }
}
