using Microsoft.Framework.DependencyInjection;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.Framework.OptionsModel;

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
                
                    var admin = new ApplicationUser { UserName = "admin" };
                    var guest = new ApplicationUser { UserName = "guest" };
                    
                    await userManager.CreateAsync(admin, "v3rY.h4rd t0_gu3!5");
                    await userManager.CreateAsync(guest, "gU35t!");
                    
                    context.SaveChanges();
                }
            }
		}
	}
}