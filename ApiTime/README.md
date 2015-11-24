# Api Time

## Project.json

```json
"Microsoft.AspNet.Mvc": "6.0.0-beta8",
```

## Startup.cs

```cs
using Microsoft.AspNet.Builder;
using Microsoft.Framework.DependencyInjection;

namespace HelloWorld
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
        }
        
        public void Configure(IApplicationBuilder app)
        {
            app.UseMvc();
        }
    }
}
```

## Model and api controller

```cs
namespace Udan.Models
{
	public class Technology
	{
		public string Name { get; set; }
	}
}
```

```cs
using System.Collections.Generic;
using Udan.Models;
using Microsoft.AspNet.Mvc;

namespace Udan.Api
{
	[Route("api/technologies")]
	public class TechnologyController : Controller
	{
		public ActionResult Get()
		{
			var technologies = new List<Technology>();
			technologies.Add(new Technology
			{
				Name = "Ubuntu"
			});
			technologies.Add(new Technology
			{
				Name = "Docker"
			});
			technologies.Add(new Technology
			{
				Name = "ASP.NET"
			});
			
			return Json(technologies);
		}
	}
}
```