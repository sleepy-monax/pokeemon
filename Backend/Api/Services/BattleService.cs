using System;
using System.Collections.Generic;
using System.Linq;
using Api.SessionServices;
using Infrastructure;
using Infrastructure.Json;
using Infrastructure.SqlServer.Creatures;
using Infrastructure.SqlServer.UserItems;
using Infrastructure.SqlServer.Users;
using Infrastructure.WebSockets;
using Model.Battle;
using Model.Creature;
using Model.Messages;
using Model.User;
using Model.UserItems;

namespace Api.Services
{
    public class BattleService
    {
        private IUserRepository _userRepository = new SqlServerUserRepository();
        private ICreatureRepository _creatureRepository = new SqlServerCreatureRepository();
        private IUserItemsRepository _userItemsRepository = new SqlServerUserItemsRepository();

        private IdAllocator _allocator = new IdAllocator("battle");
        private Dictionary<string, Battle> _battles = new Dictionary<string, Battle>();

        private Player CreatePlayer(int id)
        {
            var creatures = _creatureRepository
                .GetByUser(id)
                .ToList()
                .FindAll(creature => creature.Pickable)
                .ToArray();

            var items = _userItemsRepository
                .GetByUser(id)
                .Select(userItems => JsonItem.GetByName(userItems.NameItem))
                .ToList();

            var player = new Player
            {
                Creatures = creatures,
                Items = items,
            };

            return player;
        }

        private void JoinBattle(Session session, int playerId, Battle battle)
        {
            LeaveBattle(session);

            var player = CreatePlayer(playerId);

            player.OnMessageSent = message => session.Send(message);
            battle.Join(player);

            session.MountService(new BattleSessionService
            {
                Player = player,
                Battle = battle
            });
        }

        private void LeaveBattle(Session session)
        {
            session.WithService<BattleSessionService>(service =>
            {
                service.Battle.Leave(service.Player);

                if (!service.Battle.IsAppening)
                {
                    _battles.Remove(service.Battle.Id);
                    _allocator.Free(service.Battle.Id);
                }

                session.UnMountService<BattleSessionService>();
            });
        }

        public BattleService(SessionService ss)
        {
            ss.RegisterRequestHandler<ClientCreate>((session, message) =>
            {
                var battle = new Battle(_allocator.Alloc());
                JoinBattle(session, message.UserId, battle);
            });

            ss.RegisterRequestHandler<ClientJoin>(async (session, message) =>
            {
                var battle = _battles[message.BattleId];

                if (battle != null)
                {
                    JoinBattle(session, message.UserId, battle);
                }
                else
                {
                    await session.Send(new ServerError("no-such-battle"));
                }
            });

            ss.RegisterRequestHandler<ClientLeave>((session, message) =>
            {
                LeaveBattle(session);
            });

            ss.RegisterRequestHandler<ClientAttack>((session, message) =>
            {
                session.WithService<BattleSessionService>(service =>
                {
                    service.Battle.Attack(service.Player, message);
                });
            });

            ss.RegisterRequestHandler<ClientUseItem>((session, message) =>
            {
                session.WithService<BattleSessionService>(service =>
                {
                    service.Battle.Use(service.Player, message);
                });
            });

            ss.RegisterRequestHandler<ClientSwitchCreature>((session, message) =>
            {
                session.WithService<BattleSessionService>(service =>
                {
                    service.Battle.Switch(service.Player, message);
                });
            });

            ss.RegisterRequestHandler<ClientChat>((session, message) =>
            {
                return ss.Broadcast(message);
            });
        }

        public List<string> GetAvailable()
        {
            return _battles.Keys.ToList();
        }
    }
}