using System;
using System.Collections.Generic;
using System.Text;

namespace AsyncAwaitLesson
{
    public class SuperClass
    {
        async List<User> MakeDatabaseCall()
        {
            return await GetUsers();
        }
        static async Task<List<User>> GetUsers()
        {
            using (var context = new AsyncDbContext())
            {
                return await context.Users.ToListAsync();
            }
        }
    }
}
