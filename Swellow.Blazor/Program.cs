using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Swellow.Blazor.Services;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Swellow.Blazor
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");


            // BootstrapBlazor
            builder.Services.AddBootstrapBlazor();

            // 添加HttpClient 服务
            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            // 后端服务
            builder.Services.AddHttpClient<LibraryService>(client =>
            {
                client.BaseAddress = new Uri("http://localhost:8099");
            });
            builder.Services.AddHttpClient<MediaService>( client => 
            {
                client.BaseAddress = new Uri("http://localhost:8099");
            });

            await builder.Build().RunAsync();
        }
    }
}
