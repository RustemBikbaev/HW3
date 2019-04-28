using System;
using System.Threading.Tasks;

using MassTransit;

// тут была зависимость от homework3.Services
using ModulBank3.Models;
using ModulBank3.Commands;

namespace ModulBank3.BusinessLogic
{
    public class AppendUsersRequestHandler
    {
        private readonly IBus _bus;

        public AppendUsersRequestHandler(IBus bus)
        {
            _bus = bus;
        }

        public Task<User> Handle(User user)
        {
            Guid guid = Guid.NewGuid();
            user.Id = guid;

            // было так: _userInfoService.AppendUser(user);
            _bus.Send(new AppendUserCommand()
            {
                user = user
            });

            return Task.FromResult<User>(user);
        }
    }
}