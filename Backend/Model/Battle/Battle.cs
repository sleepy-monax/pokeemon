using System;
using System.Diagnostics;
using System.Linq;
using Model.Messages;

namespace Model.Battle
{
    public class Battle
    {
        public String Id { get;  }
        private bool _turn = false;

        private Player _firstPlayer;
        private Player _secondPlayer;
        
        Player CurrentPlayer()
        {
            if (_turn)
            {
                return _firstPlayer;
            }

            return _secondPlayer;
        }
        
        Player OtherPlayer()
        {
            if (!_turn)
            {
                return _firstPlayer;
            }
            else
            {
                return _secondPlayer;
            }
        }
        
        public Battle(String id)
        {
            Id = id;
        }
        
        bool BeginTurn(Player player)
        {
            if (CurrentPlayer() != player)
            {
                player.SendMessage(new ServerError("not-your-turn"));
                return false;
            }

            if (CurrentPlayer().Defeated)
            {
                CurrentPlayer().SendMessage(new ServerError("player-defeated"));
                return false;
            }

            return true;
        }

        void EndTurn()
        {
            CurrentPlayer().SendMessage(new ServerUpdateStats
            {
                CreatureId = CurrentPlayer().Active,
                Stats =  CurrentPlayer().ActiveCreature.Stats
            });
            
            OtherPlayer().SendMessage(new ServerUpdateStats
            {
                CreatureId = OtherPlayer().Active,
                Stats =  OtherPlayer().ActiveCreature.Stats
            });
            
            if (OtherPlayer().Defeated)
            {
                CurrentPlayer().SendMessage(new ServerClientWin());
                OtherPlayer().SendMessage(new ServerClientLoose());
            }

            _turn = !_turn;
        }

        public void Attack(Player player, ClientAttack message)
        {
            if (!BeginTurn(player))
            {
                return;
            }
            
            if (CurrentPlayer().ActiveCreature.Defeated)
            {
                CurrentPlayer().SendMessage(new ServerError("creature-defeated"));
                return;
            }
            
            var attack = CurrentPlayer()
                .ActiveCreature
                .AvaillableActions
                .First(att => att.Name == message.AttackName);

            if (attack == null)
            {
                CurrentPlayer().SendMessage(new ServerError("no-such-attack"));
            }
            
            OtherPlayer().ActiveCreature.Effects.Add(attack.Effect);
            attack.PowerPoint--;
            
            EndTurn();
        }

        public bool Join(Player player)
        {
            if (_firstPlayer == null)
            {
                _firstPlayer = player;
                _firstPlayer.SendMessage(new ServerBattleMessage{BattleId = Id});
                return true;
            }

            if (_secondPlayer == null)
            {
                _secondPlayer = player;
                _secondPlayer.SendMessage(new ServerBattleMessage{BattleId = Id});
                return true;
            }

            return false;
        }
        
        public void Leave(Player player)
        {
            if (_firstPlayer == player)
            {
                _firstPlayer = null;
            }
            else if (_secondPlayer == player)
            {
                _secondPlayer = null;
            }
        }
    }
}