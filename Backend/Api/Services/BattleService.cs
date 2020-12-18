using System;
using Api.SessionServices;
using Infrastructure;
using Infrastructure.SqlServer.Creatures;
using Infrastructure.SqlServer.UserItems;
using Model.Battle;
using Model.Creature;
using Model.Messages;
using Model.UserItems;

namespace Api.Services
{
    public class BattleService
    {
        private ICreatureRepository _creatureRepository = new SqlServerCreatureRepository();
        private IUserItemsRepository _userItemsRepository = new SqlServerUserItemsRepository();
        
        private IdAllocator _allocator = new IdAllocator("battle");
        
        public BattleService(SessionService bs)
        {
            bs.RegisterRequestHandler<ClientCreate>((session, message) =>
            {
                session.WithService<BattleSessionService>(service =>
                {
                    service.Battle.Leave(service.Player);
                    session.UnMountService<BattleSessionService>();
                });

                var battle = new Battle(_allocator.Alloc());

                session.MountService(new BattleSessionService
                {
                    
                });
            });

            bs.RegisterRequestHandler<ClientJoin>((session, payload) =>
            {
            });

            bs.RegisterRequestHandler<ClientLeave>((session, payload) =>
            {
            });

            bs.RegisterRequestHandler<ClientAttack>((session, payload) =>
            {
            });

            bs.RegisterRequestHandler<ClientUseItem>((session, payload) =>
            {
            });

            bs.RegisterRequestHandler<ClientSwitchCreature>((session, payload) =>
            {
            });

            bs.RegisterRequestHandler<ClientChat>((session, payload) =>
            {
                Console.WriteLine("Chat: " + payload.Text);
                return bs.Broadcast(payload);
            });
        }
    }
}