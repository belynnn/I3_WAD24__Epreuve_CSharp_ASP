using MVC.Handlers;
using MVC.Handlers.ActionFilters;
using MVC.Models.Auth;
using BLL.Entities;
using Common.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ASP_MVC.Controllers
{
	public class AuthController : Controller
	{
		private IUserRepository<BLL.Entities.User> _userService;
		private SessionManager _sessionManager;

		public AuthController(
			IUserRepository<User> userService,
			SessionManager sessionManager
			)
		{
			_userService = userService;
			_sessionManager = sessionManager;
		}

		public IActionResult Index()
		{
			return RedirectToAction(nameof(Login));
		}

		[AnonymousNeeded]
		public IActionResult Login()
		{
			return View();
		}

		[HttpPost]
		[AnonymousNeeded]
		public IActionResult Login(AuthLoginForm form)
		{
			try
			{
				if (!ModelState.IsValid) throw new ArgumentException(nameof(form));
				int id = _userService.CheckPassword(form.Email, form.MotDePasse);

				// définir la variable de session
				User user = _userService.Get(id);

				ConnectedUser sessionUser = new ConnectedUser()
				{
					UtilisateurId = user.UtilisateurId,
					Email = user.Email,
					ConnectedAt = DateTime.Now
					//Role = user.Role.ToString()
				};
				_sessionManager.Login(sessionUser);
				return RedirectToAction("Details", "User", new { id = id });
			}
			catch (Exception)
			{
				return View();
			}
		}

		[ConnectionNeeded]
		public IActionResult Logout()
		{
			return View();
		}

		[HttpPost]
		[ConnectionNeeded]
		public IActionResult Logout(IFormCollection form)
		{
			try
			{
				_sessionManager.Logout();
				return RedirectToAction(nameof(Login));
			}
			catch (Exception)
			{
				return View();
			}
		}
	}
}