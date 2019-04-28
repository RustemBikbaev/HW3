using System.Threading.Tasks;
using ModulBank3.Commands;
using MassTransit;
using ModulBank3.Services.Interfaces;


namespace ModulBank3.Consumers
{
    public class AppendUserConsumer : IConsumer<AppendUserCommand>
    {
        private readonly IUserInfoService _userInfoService;

        public AppendUserConsumer(IUserInfoService userInfoService)
        {
            _userInfoService = userInfoService;
        }

        public async Task Consume(ConsumeContext<AppendUserCommand> context)
        {
            await _userInfoService.AppendUser(context.Message.user);
        }
    }
}
