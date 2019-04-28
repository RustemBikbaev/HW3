using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ModulBank3.Services.Interfaces;
using ModulBank3.Models;

namespace ModulBank3.BusinessLogic
{
    public class GetUsersInfoRequestHandler
    {
        private readonly IUserInfoService _userInfoService;

        public GetUsersInfoRequestHandler(IUserInfoService userInfoService)
        {
            _userInfoService = userInfoService;
        }

        public Task<User> Handle(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentException("Некорректный идентификатор пользователя", nameof(id));
            }

            return _userInfoService.GetById(id);
        }

        

    }

    //public class AppendUsersRequestHandler
    //{
    //    private readonly IAppendUser _appendUser;

    //    public AppendUsersRequestHandler(IAppendUser appendUser)
    //    {
    //        _appendUser = appendUser;
    //    }

    //    public void AppendUser(User user)
    //    {
    //        Guid guid = Guid.NewGuid();
    //        user.Id = guid;
    //        _appendUser.AppendUser(user);
    //    }

    //}

}
