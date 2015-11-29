using Microsoft.Data.Entity;
using Microsoft.Framework.DependencyInjection;
using System;
using System.Linq;
using Microsoft.Data.Entity.Storage;

namespace Udan.Models
{
	public static class SampleData
	{
		public static void Initialize(IServiceProvider serviceProvider)
		{
            var context = serviceProvider.GetService<TechnologyContext>();
            
            context.Database.EnsureCreated();
            
            if (!context.Technologies.Any()) 
            {
                context.Technologies.AddRange(
                    new Technology { Name = "Ubuntu" },
                    new Technology { Name = "Docker" },
                    new Technology { Name = "ASP.NET" }
                );
                context.SaveChanges();    
            }
		}
	}
}