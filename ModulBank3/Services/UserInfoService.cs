using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using ModulBank3.Models;
using ModulBank3.Services.Interfaces;
using Npgsql;

namespace ModulBank3.Services
{
    public class UserInfoService : IUserInfoService
    {
        private const string ConnectionString =
            "host=localhost;port=5432;database=homework3;username=postgres;password=1";

        //public async Task<User> GetById(Guid id)
        //{
        //    User user = new User
        //    {
        //        Email = "test@test.ru",
        //        Id = id,
        //        Nickname = "test",
        //        Phone = "+7 987 654 32 10"
        //    };

        //    return await Task.FromResult<User>(user);
        //}


        public async Task<User> GetById(Guid id)
        {
            using (var connection = new NpgsqlConnection(ConnectionString))
            {
                return await connection.QuerySingleAsync<User>(
                    "SELECT * FROM users WHERE Id = @id", new { id });
            }
        }
    }

}
