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

        private Player? _firstPlayer;
        private Player? _secondPlayer ;

        public bool IsAppening => _firstPlayer != null && _secondPlayer != null;
        
        Player? CurrentPlayer()
        {
            if (_turn)
            {
                return _firstPlayer;
            }

            return _secondPlayer;
        }
        
        Player? OtherPlayer()
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

            if (OtherPlayer().Defeated)
            {
                CurrentPlayer().SendMessage(new ServerError("you-already-win"));
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

        public void Switch(Player player, ClientSwitchCreature message)
        {
            if (!BeginTurn(player))
            {
                return;
            }

            var oldActive = CurrentPlayer().Active;
            
            CurrentPlayer().Active = message.CreatureIndex;

            if (CurrentPlayer().ActiveCreature.Defeated)
            {
                player.SendMessage(new ServerError("creature-not-able-to-fight"));

                CurrentPlayer().Active = oldActive;
            }
            else
            {
                EndTurn();
            }
        }

        public void Use(Player player, ClientUseItem message)
        {
            if (!BeginTurn(player))
            {
                return;
            }

            var item = player.Items.First(item => item.Name == message.Item);

            if (item == null)
            {
                player.SendMessage(new ServerError("no-such-item"));
                return;
            }

            if (message.TargetEnemy)
            {
                OtherPlayer().ActiveCreature.Effects.Add(item.Effect);
            }
            else
            {
                CurrentPlayer().ActiveCreature.Effects.Add(item.Effect);
            }

            EndTurn();
        }

        public bool Join(Player player)
        {
            if (_firstPlayer == null)
            {
                _firstPlayer = player;
                _firstPlayer.SendMessage(new ServerJoinBattle{BattleId = Id, Player = player});

                if (_secondPlayer != null)
                {
                    _firstPlayer.SendMessage(new ServerOtherJoinBattle{BattleId = Id, Player = _secondPlayer});
                    _secondPlayer.SendMessage(new ServerOtherJoinBattle{BattleId = Id, Player = player});
                }
                
                return true;
            }

            if (_secondPlayer == null)
            {
                _secondPlayer = player;
                _secondPlayer.SendMessage(new ServerJoinBattle{BattleId = Id, Player = player});


                if (_firstPlayer != null)
                {
                    _firstPlayer.SendMessage(new ServerOtherJoinBattle{BattleId = Id, Player = player});
                    _secondPlayer.SendMessage(new ServerOtherJoinBattle{BattleId = Id, Player = _firstPlayer});
                }
                
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