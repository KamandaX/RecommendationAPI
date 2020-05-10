using API.Models;
using API.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using JsonSerializer = API.Services.JsonSerializer;

namespace API
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
            services.AddSingleton<Iserializer, JsonSerializer>();
            services.AddSingleton<IErrorFormatter, JsonErrorFormatter>();
            //services.AddDbContext<ApiContext>(opt => opt.UseInMemoryDatabase("API"));
            var builder = new MySqlConnectionStringBuilder(Configuration.GetConnectionString("DefaultConnection"))
            {
                Server = Configuration["Server"],
                Database = Configuration["Database"],
                UserID = Configuration["Uid"],
                Password = Configuration["DbPassword"]
            };
            services.AddDbContext<ApiContext>(opt =>
                opt.UseMySql(builder.ConnectionString));
            services.AddControllers().AddNewtonsoftJson(opt =>
                {
                    opt.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                    //opt.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
                });

            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", p =>
                {
                    p.AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod();
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ApiContext context)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                var seed = new SeedData(context);
                seed.Seed();
            }

            //app.UseHttpsRedirection();

            app.UseCors("AllowAll");

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
