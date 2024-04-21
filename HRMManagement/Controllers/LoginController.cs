using HRMManagement.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace HRMManagement.Controllers
{
	public class LoginController : Controller
	{
		private readonly ILogger<LoginController> _logger;
		private readonly HrmContext _context;

		public LoginController(ILogger<LoginController> logger, HrmContext context)
		{
			_logger = logger;
			_context = context;
		}

		public IActionResult Index()
		{
			return View();
		}

		[HttpPost]
		[Route("/LoginController/Login")]
		public async Task<IActionResult> Login(Taikhoan model, string returnUrl = null)
		{
			var user = await _context.Taikhoans.FirstOrDefaultAsync(u => u.TenDangNhap == model.TenDangNhap);

			if (user != null)
			{
				if (user.MatKhau == model.MatKhau)
				{
					_logger.LogInformation("User logged in successfully.");
					return RedirectToAction("Index", "Dashboard");
				}
			}

			ModelState.AddModelError("", "Invalid username or password.");
			return View("Index");
		}

		public IActionResult Login(string provider)
		{
			// Redirect to Facebook login page
			var redirectUrl = Url.Action("Callback", "Account", new { provider = provider });
			var properties = new AuthenticationProperties
			{
				RedirectUri = redirectUrl
			};
			return Challenge(properties, provider);
		}
	}
}
