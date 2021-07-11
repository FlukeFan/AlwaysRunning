using System;
using System.IO;
using System.Threading;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace Server
{
    public class Program
    {
        private const string _logFile = "running.log";

        private static DateTimeOffset _startedAt;
        private static Timer _timer;

        public static DateTimeOffset StartedAt => _startedAt;

        public static void Main(string[] args)
        {
            using (_timer = new Timer(WriteToLog))
            {
                _startedAt = DateTime.Now;
                Log($"Site STARTED at {_startedAt}");

                _timer.Change(3000, Timeout.Infinite);

                CreateHostBuilder(args).Build().Run();
            }

            Log($"STOPPED at {DateTimeOffset.Now}");
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

        private static void WriteToLog(object _)
        {
            try
            {
                Log($"Site running at {DateTimeOffset.Now}");
            }
            catch { }
            finally
            {
                _timer.Change(3000, Timeout.Infinite);
            }
        }

        private static void Log(string message)
        {
            if (!File.Exists(_logFile))
                File.WriteAllText(_logFile, $"Log started at {DateTimeOffset.Now}\n");

            File.AppendAllText(_logFile, $"{message}\n");
        }
    }
}
