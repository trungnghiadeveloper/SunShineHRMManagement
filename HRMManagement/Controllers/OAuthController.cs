using HRMManagement.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace HRMManagement.Controllers
{
	public class OAuthController : Controller
	{
		private const string CookieUserId = "UserId";
		private const string CookieUserName = "UserName";
		private readonly HrmContext _context;
		private readonly ILogger<OAuthController> _logger;

		public OAuthController(ILogger<OAuthController> logger, HrmContext context)
		{
			_logger = logger;
			_context = context;
		}

		[HttpGet]
		[Route("OAuth/Login")]
		public IActionResult Login()
		{
			return View();
		}

        [HttpGet]
        [Route("OAuth/Register")]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
		[Route("OAuth/Login")]
		public async Task<IActionResult> Login(Taikhoan model)
		{
			bool remember = Request.Form["remember"] == "on";
			_logger.LogInformation(remember.ToString());
			var user = await _context.Taikhoans.FirstOrDefaultAsync(u => u.TenDangNhap == model.TenDangNhap);

			if (user != null)
			{
				if (user.MatKhau == model.MatKhau)
				{
					_logger.LogInformation("User logged in successfully.");
					await SaveUserToCookieAsync(user, remember);

					return RedirectToAction("Index", "Dashboard");
				} else
				{
					ModelState.AddModelError("MatKhau", "Password is not correct.");
				}
			} else
			{
				ModelState.AddModelError("TenDangNhap", "Username is not exist.");
			}

			return View("Login");
		}

		[HttpPost]
		[Route("OAuth/Register")]
		public async Task<IActionResult> Register(Taikhoan model)
		{
			if (!string.IsNullOrEmpty(model.TenDangNhap) && !string.IsNullOrEmpty(model.MatKhau))
			{
				var existingUser = await _context.Taikhoans.FirstOrDefaultAsync(u => u.TenDangNhap == model.TenDangNhap);
				if (existingUser != null)
				{
					ModelState.AddModelError("TenDangNhap", "Username already exists.");
					return View("Register");
				}

				var newUser = new Taikhoan
				{
					TenDangNhap = model.TenDangNhap,
					MatKhau = model.MatKhau,
				};

				_context.Taikhoans.Add(newUser);
				await _context.SaveChangesAsync();

				return View("Login");
			}
			else
			{
				ModelState.AddModelError("TenDangNhap", "Username or password cannot be empty.");
				return View("Register");
			}
		}

		private async Task SaveUserToCookieAsync(Taikhoan account, bool remember)
		{
			var options = new CookieOptions
			{
				IsEssential = true
			};

			if (remember)
			{
				options.Expires = DateTime.Now.AddDays(7);
			}

			Response.Cookies.Append(CookieUserId, account.Id.ToString(), options);
			Response.Cookies.Append(CookieUserName, account.TenDangNhap.ToString(), options);
		}
	}
}
