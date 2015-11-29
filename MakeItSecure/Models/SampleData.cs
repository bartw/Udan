using Microsoft.Framework.DependencyInjection;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;

namespace Udan.Models
{
	public static class SampleData
	{
		public static async Task Initialize(IServiceProvider serviceProvider)
		{
            var context = serviceProvider.GetService<UdanDbContext>();
            
            if (await context.Database.EnsureCreatedAsync())
            {
                if (!context.Technologies.Any()) 
                {
                    context.Technologies.AddRange(
                        new Technology { Name = "Ubuntu" },
                        new Technology { Name = "Docker" },
                        new Technology { Name = "ASP.NET" }
                    );
                    
                    var userManager = serviceProvider.GetService<UserManager<ApplicationUser>>();
                
                    //var admin = new ApplicationUser { UserName = "admin" };
                    var guest = new ApplicationUser { UserName = "guest" };
                    
                    //await userManager.CreateAsync(admin, "v3ry h4rd t0 gu355");
                    await userManager.CreateAsync(guest, "gU3st");
                    
                    context.SaveChanges();
                }
            }
		}
	}
}