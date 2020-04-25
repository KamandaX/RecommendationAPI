using API.Models;
using API.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MySql.Data.MySqlClient;

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
            var builder = new MySqlConnectionStringBuilder(Configuration.GetConnectionString("DefaultConnection"));
            builder.Server = Configuration["Server"];
            builder.Database = Configuration["Database"];
            builder.UserID = Configuration["Uid"];
            builder.Password = Configuration["DbPassword"];
            services.AddDbContext<ApiContext>(opt =>
                opt.UseMySql(builder.ConnectionString));
            services.AddControllers();
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

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
