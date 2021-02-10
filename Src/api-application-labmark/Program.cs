using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace Labmark
{
    public static class Program
    {
        [STAThread]
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                    webBuilder.UseKestrel()
                    .ConfigureKestrel(options =>
                    {
                        options.ListenAnyIP(443);
                        options.ListenAnyIP(80);
                    });
                });
    }
}
