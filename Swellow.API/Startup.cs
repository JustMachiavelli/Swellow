using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Swellow.API.Sql;
using Swellow.API.Sql.Init;
using Swellow.Shared.Environment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Swellow.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // WebApi������
            services.AddControllers();
            // ���ݿ�����
            services.AddDbContext<SwellowDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("SwellowDbConnection")));
            // ���ݿ�EF����
            services.AddScoped<IDbManager, DbManager>();
            // Dto�Զ�ӳ��
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // ����˷�������ѡ���򿪷��߻����û�չʾ
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler(appBuilder =>
                {
                    appBuilder.Run(async context =>
                    {
                        context.Response.StatusCode = 500;
                        await context.Response.WriteAsync("Unexpected Error!");
                    });
                });
            }

            // ������ʾ�̬�ļ�����̬�ļ���ӱ��ش��̵�Ŀ¼·��
            app.UseStaticFiles(
                new StaticFileOptions
                {
                    // D:\MyGit\MyProjects\SwellowData\Images
                    FileProvider = new PhysicalFileProvider(LocalResources.DataImagesDirectory),
                    // /SwellowData/Images
                    RequestPath = StaticFiles.DataImagesDirectory
                }
            );
            app.UseStaticFiles(
                new StaticFileOptions
                {
                    // D:\MyGit\MyProjects\TestVideos
                    FileProvider = new PhysicalFileProvider(LocalResources.TestMoviesDirectory),
                    // /TestVideos
                    RequestPath = StaticFiles.TestVideosDirectory
                }
            );

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
