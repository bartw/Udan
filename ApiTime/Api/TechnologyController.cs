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