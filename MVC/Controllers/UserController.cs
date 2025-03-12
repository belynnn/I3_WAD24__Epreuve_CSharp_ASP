using MVC.Handlers.ActionFilters;
using MVC.Mappers;
using MVC.Models.User;
using BLL.Entities;
using Common.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MVC.Controllers
{
	public class UserController : Controller
	{
		private IUserRepository<BLL.Entities.User> _userService;

		public UserController(IUserRepository<BLL.Entities.User> userService)
		{
			_userService = userService;
		}

		// GET: UserController
		public ActionResult Index()
		{
			try
			{
				IEnumerable<UserListItem> model = _userService.Get().Select(bll => bll.ToListItem());
				return View(model);
			}
			catch (Exception)
			{
				return RedirectToAction("Error", "Home");
			}
		}

		// GET: UserController/Details/5
		public ActionResult Details(int id)
		{
			try
			{
				UserDetails model = _userService.Get(id).ToDetails();
				return View(model);
			}
			catch (Exception)
			{
				return RedirectToAction("Error", "Home");
			}
		}

		// GET: UserController/Create
		[AnonymousNeeded]
		public ActionResult Create()
		{
			return View();
		}

		// POST: UserController/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		[AnonymousNeeded]
		public ActionResult Create(UserCreateForm form)
		{
			try
			{
				if (!form.Consentement) ModelState.AddModelError(nameof(form.Consentement), "Vous devez lire et accepter les conditions générales d'utilisation.");
				if (!ModelState.IsValid) throw new ArgumentException();
				int id = _userService.Insert(form.ToBLL());
				return RedirectToAction(nameof(Details), new { id = id });
			}
			catch
			{
				return View();
			}
		}

		// GET: UserController/Edit/5
		public ActionResult Edit(int id)
		{
			try
			{
				UserEditForm model = _userService.Get(id).ToEditForm();
				return View(model);
			}
			catch (Exception)
			{
				return RedirectToAction("Error", "Home");
			}
		}

		// POST: UserController/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(int id, UserEditForm form)
		{
			try
			{
				if (!ModelState.IsValid) throw new ArgumentException(nameof(form));
				_userService.Update(id, form.ToBLL());
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return RedirectToAction(nameof(Edit), new { id = id });
			}
		}

		// GET: UserController/Delete/5
		public ActionResult Delete(int id)
		{
			try
			{
				UserDelete model = _userService.Get(id).ToDelete();
				return View(model);
			}
			catch (Exception)
			{
				return RedirectToAction("Error", "Home");
			}
		}

		// POST: UserController/Delete/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Delete(int id, UserDelete form)
		{
			try
			{
				_userService.Delete(id);
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return RedirectToAction(nameof(Delete), new { id = id });
			}
		}

		// changement de rôle si y'a l'temps
	}
}
