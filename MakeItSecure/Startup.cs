using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.Framework.DependencyInjection;
using Microsoft.Framework.Configuration;
using Udan.Models;
using Microsoft.Dnx.Runtime;
using Microsoft.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace HelloWorld
{
    public class Startup
    {
        public IConfiguration Configuration { get; set; }
        
        public Startup(IHostingEnvironment env, IApplicationEnvironment appEnv)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(appEnv.ApplicationBasePath)
                .AddJsonFile("config.json")
                .AddEnvironmentVariables();
                
            Configuration = builder.Build();
        }
        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            
            services.AddEntityFramework()
                .AddSqlite()
                .AddDbContext<UdanDbContext>(options => options.UseSqlite(Configuration["Data:ConnectionString"]));
                
            services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<UdanDbContext>();
        }
        
        public void Configure(IApplicationBuilder app)
        {
            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseIdentity();
            app.UseMvc();
            
            SampleData.Initialize(app.ApplicationServices).Wait();
        }
    }
}
