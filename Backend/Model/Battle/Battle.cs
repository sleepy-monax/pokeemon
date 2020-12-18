using System;

namespace Model.Battle
{
    public class Battle
    {
        public bool _turn = false;

        private Player _firstPlayer;
        private Player _secondlayer;

        public Action<Player> OnPlayerJoin;
        public Action<Player> OnPlayerLeave;

        Player CurrentPlayer()
        {
            if (_turn)
            {
                return _firstPlayer;
            }

            return _secondlayer;
        }


        Player OtherPlayer()
        {
            if (!_turn)
            {
                return _firstPlayer;
            }
            else
            {
                return _secondlayer;
            }
        }

        public bool Join(Player player)
        {
            if (_firstPlayer == null)
            {
                _firstPlayer = player;
                OnPlayerJoin?.Invoke(player);
                return true;
            }

            if (_secondlayer == null)
            {
                _secondlayer = player;
                OnPlayerJoin?.Invoke(player);
                return true;
            }

            return false;
        }

        public void Leave(Player player)
        {
            if (_firstPlayer == player)
            {

            }
        }
    }
}