using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ModulBank3.Models;
using Microsoft.AspNetCore.Mvc;

namespace ModulBank3.Services.Interfaces
{
    public interface IUserInfoService
    {
        Task<User> GetById(Guid id);
        Task<IActionResult> AppendUser(User user);

    }

    //public interface AppendUser
    //{
    //    Task<IActionResult> AppendUser(User user);
    //}

}
