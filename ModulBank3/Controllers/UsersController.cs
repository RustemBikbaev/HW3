using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModulBank3.BusinessLogic;
using ModulBank3.Models;

namespace ModulBank3.Controllers
{
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        private readonly GetUsersInfoRequestHandler _getUsersInfoRequestHandler;
       private readonly AppendUsersRequestHandler _appendUsersRequestHandler;

        public UsersController(GetUsersInfoRequestHandler getUsersInfoRequestHandler, AppendUsersRequestHandler appendUsersRequestHandler)
        {
            _getUsersInfoRequestHandler = getUsersInfoRequestHandler;
            _appendUsersRequestHandler = appendUsersRequestHandler;
        }


        [HttpGet("{id}")]
        public Task<User> GetUserInfo(Guid id)
        {
            return _getUsersInfoRequestHandler.Handle(id);
        }

        [HttpPost("append")]
        public Task<User> AppendUser([FromBody] User user)
        {
            Guid guid = Guid.NewGuid();
            user.Id = guid;

            _appendUsersRequestHandler.Handle(user);
            return Task.FromResult<User>(user);
        }

    }

}