using System;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace Server
{
    public class Program
    {
        public static DateTimeOffset _startedAt;

        public static DateTimeOffset StartedAt => _startedAt;

        public static void Main(string[] args)
        {
            _startedAt = DateTime.Now;
            File.WriteAllText("running.txt", $"Site running at {_startedAt}");

            CreateHostBuilder(args).Build().Run();

            File.AppendAllText("running.txt", $" Stopped at {DateTimeOffset.Now}");
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
