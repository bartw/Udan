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
            var context = new TechnologyContext();
            context.Database.EnsureCreated();
            context.Technologies.AddRange(
                new Technology { Name = "Ubuntu" },
                new Technology { Name = "Docker" },
                new Technology { Name = "ASP.NET" }
            );
            context.SaveChanges();
            /*
			var context = serviceProvider.GetService<TechnologyContext>();
			
			if (serviceProvider.GetService<IRelationalDatabaseCreator>().Exists())
            {
                if (!context.Technologies.Any())
                {
                    context.Technologies.AddRange(
                        new Technology { Name = "Ubuntu" },
                        new Technology { Name = "Docker" },
                        new Technology { Name = "ASP.NET" }
                    );
                    context.SaveChanges();
                }
            }*/
		}
	}
}