using System.Collections.Generic;
using Udan.Models;
using Microsoft.AspNet.Mvc;
using Microsoft.Framework.DependencyInjection;
using System.Linq;
using Microsoft.Data.Entity;

namespace Udan.Api
{		
	[Route("api/technologies")]
	public class TechnologyController : Controller
	{
		private TechnologyContext _context;
	
		public TechnologyController (TechnologyContext context)
		{
            _context = context;
        }
		
		[HttpGet]
		public IActionResult Get()
		{
			return Json(_context.Technologies);
		}
		
		[HttpGet("{id}", Name="GetTechnology")]
		public IActionResult Get(int id)
		{
			var technology = _context.Technologies.FirstOrDefault(t => t.Id == id);
			
			if (technology == null)
			{
				return HttpNotFound();
			}
			return Json(technology);
		}
		
		[HttpPost]
		public IActionResult Create([FromBody] Technology technology)
		{
			if (technology == null)
			{
				return HttpBadRequest();		
			}
			
			_context.Technologies.Add(technology);
			_context.SaveChanges();
			
			return CreatedAtRoute("GetTechnology", new { controller = "Technology", id = technology.Id }, technology);
		}
		
		[HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Technology technology)
        {
            if (technology == null || technology.Id != id)
            {
                return HttpBadRequest();
            }

            var count = _context.Technologies.Count(t => t.Id == id);
            if (count == 0)
            {
                return HttpNotFound();
            }
			
			_context.Technologies.Attach(technology);
			_context.Entry(technology).State = EntityState.Modified;
			_context.SaveChanges();
			
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var technology = _context.Technologies.FirstOrDefault(t => t.Id == id);
            if (technology == null)
            {
                return HttpNotFound();
            }
			
			_context.Technologies.Remove(technology);
            _context.SaveChanges();

            return Json(technology);
        }
		
		protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            base.Dispose(disposing);
        }
	}
}