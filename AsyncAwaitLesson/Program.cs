using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace AsyncAwaitLesson
{
    class Program
    {
        static async void Main(string[] args)
        {
            var result = await GetUsers();
            //await SendMessage("+132324165", "good");
            //var sumResult = await SumLongProcess(15, 10);
            //await CreateFileAsync("file");
        }

        

        static async Task SendMessage(string to, string text)
        {
            const string accountSid = "ACXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX";
            const string authToken = "your_auth_token";

            TwilioClient.Init(accountSid, authToken);

            await MessageResource.CreateAsync(
                body: text,
                from: new Twilio.Types.PhoneNumber("+15017122661"),
                to: new Twilio.Types.PhoneNumber(to)
            );
        }

        static async Task CreateFileAsync(string name)
        {
            //File.Create($"{name}.txt").Close();
            using(var stream = File.Create($"{name}.txt"))
            {
                var text = "some text";
                var bytes = System.Text.Encoding.UTF8.GetBytes(text);
                await stream.WriteAsync(bytes, 0, bytes.Length);
            }
        }

        static async Task<List<User>> GetUsers()
        {
            using(var context = new AsyncDbContext())
            {
                return await context.Users.ToListAsync();
            }
        }

        static Task<int> SumLongProcess(int x, int y)
        {
            return Task.Run(() =>
            {
                Thread.Sleep(10000);
                return x + y;
            });
        }

    }
}
