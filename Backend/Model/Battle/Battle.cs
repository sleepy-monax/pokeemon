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

        Player CurrentPlayer(Player player)
        {
            if (_turn)
            {
                return _firstPlayer;
            }
            else
            {
                return _secondlayer;
            }
        }


        Player OtherPlayer(Player player)
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

        public void Join(Player player)
        {
            if (_firstPlayer == null)
            {
                _firstPlayer = player;
                OnPlayerJoin?.Invoke(player);
            }
            else if (_secondlayer == null)
            {
                _secondlayer = player;
                OnPlayerJoin?.Invoke(player);
            }
        }

        public void Leave(Player player)
        {
            if (_firstPlayer == player)
            {

            }
        }
    }
}