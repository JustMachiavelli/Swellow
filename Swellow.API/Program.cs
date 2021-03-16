using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Swellow.SqlInit.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Swellow.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            CreateDbIfNotExists(host);

            host.Run();

            // 本来只有下面这句话
            //CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });


        private static void CreateDbIfNotExists(IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var context = services.GetRequiredService<SwellowDbContext>();

                //将 EnsureCreated 调用替换为 DbInitializer.Initialize 调用
                //context.Database.EnsureCreated();
                DbInitializer.Initialize(context);
                //try
                //{
                //    var context = services.GetRequiredService<SwellowDbContext>();

                //    //将 EnsureCreated 调用替换为 DbInitializer.Initialize 调用
                //    //context.Database.EnsureCreated();
                //    DbInitializer.Initialize(context);

                //}
                //catch (Exception ex)
                //{
                //    var logger = services.GetRequiredService<ILogger<Program>>();
                //    logger.LogError(ex, "An error occurred creating the DB.");
                //}
            }
        }
    }
}
