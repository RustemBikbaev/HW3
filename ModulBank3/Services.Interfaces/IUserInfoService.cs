using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ModulBank3.Models;

namespace ModulBank3.Services.Interfaces
{
    public interface IUserInfoService
    {
        Task<User> GetById(Guid id);
    }

}
