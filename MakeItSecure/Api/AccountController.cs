using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Mvc;
using Udan.Models;

namespace Udan.Api
{
	[Route("api/account")]
	public class AccountController : Controller
	{
		private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _signInManager;
		
		public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
		
		[HttpPost]
		public async Task<IActionResult> Login([FromBody] Account account)
		{
			if (account == null)
			{
				return HttpBadRequest();		
			}
			
			var result = await _signInManager.PasswordSignInAsync(account.UserName, account.Password, false, false);
			if (result.Succeeded)
			{
				return Ok();
			}
			return Json(result);
			return HttpUnauthorized();
		}
	}
}