using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using ModulBank3.Models;
using ModulBank3.Services.Interfaces;
using Npgsql;
using Microsoft.AspNetCore.Mvc;

namespace ModulBank3.Services
{
    public class UserInfoService : IUserInfoService
    {
        private const string ConnectionString =
            "host=localhost;port=5432;database=homework3;username=postgres;password=1";


        public async Task<User> GetById(Guid id)
        {
            using (var connection = new NpgsqlConnection(ConnectionString))
            {
                return await connection.QuerySingleAsync<User>(
                    "SELECT * FROM users WHERE Id = @id", new { id });
            }
        }
  
            public async Task<IActionResult> AppendUser(User user)
            {
                using (var connection = new NpgsqlConnection(ConnectionString))
                {
                    string query = "INSERT INTO users (id, email, nickname, phone) VALUES (@id, @email, @nickname, @phone)";

                    await connection.QuerySingleAsync<User>(query, user);
                }
                return new OkResult();
            }

        


    }

   

}
