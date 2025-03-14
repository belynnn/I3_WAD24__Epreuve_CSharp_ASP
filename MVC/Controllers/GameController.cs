using MVC.Handlers;
using MVC.Handlers.ActionFilters;
using MVC.Mappers;
using MVC.Models.Game;
using BLL.Entities;
using Common.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MVC.Controllers
{
	public class GameController : Controller
	{
		private IGameRepository<Game> _gameRepository;
		private SessionManager _sessionManager;

		public GameController(
			IGameRepository<Game> gameRepository,
			SessionManager sessionManager
			)
		{
			_gameRepository = gameRepository;
			_sessionManager = sessionManager;
		}

		// GET: GameController
		public ActionResult Index()
		{
			try
			{
				IEnumerable<GameListItem> model = _gameRepository.Get().Select(bll => bll.ToListItem());
				return View(model);
			}
			catch (Exception)
			{
				return RedirectToAction("Error", "Home");
			}
		}

		// GET: GameController/Details/5
		public ActionResult Details(int id)
		{
			try
			{
				GameDetails model = _gameRepository.Get(id).ToDetails();
				return View(model);
			}
			catch (Exception)
			{
				return RedirectToAction("Error", "Home");
			}
		}

		// GET: GameController/Create
		[ConnectionNeeded]
		public ActionResult Create()
		{
			return View();
		}

		// POST: GameController/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		[ConnectionNeeded]
		public ActionResult Create(GameCreateForm form)
		{
			try
			{
				if (!ModelState.IsValid) throw new ArgumentException(nameof(form));
				int id = _gameRepository.Insert(form.ToBLL());
				return RedirectToAction(nameof(Details), new { id });
			}
			catch
			{
				return View();
			}
		}

		// GET: GameController/Edit/5
		public ActionResult Edit(int id)
		{
			try
			{
				GameEditForm model = _gameRepository.Get(id).ToEditForm();
				return View(model);
			}
			catch (Exception ex)
			{
				TempData["ErrorMessage"] = ex.Message;
				return RedirectToAction(nameof(Index));
			}
		}

		// POST: GameController/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		[ConnectionNeeded]
		public ActionResult Edit(int id, GameEditForm form)
		{
			try
			{
				if (!ModelState.IsValid) throw new ArgumentException(nameof(form));
				_gameRepository.Update(id, form.ToBLL());
				return RedirectToAction(nameof(Details), new { id });
			}
			catch
			{
				return View();
			}
		}

		// GET: GameController/Delete/5
		[ConnectionNeeded]
		public ActionResult Delete(int id)
		{
			try
			{
				GameDelete model = _gameRepository.Get(id).ToDelete();
				return View(model);
			}
			catch (Exception)
			{
				return RedirectToAction(nameof(Index));
			}
		}

		// POST: GameController/Delete/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		[ConnectionNeeded]
		public ActionResult Delete(int id, GameDelete form)
		{
			try
			{
				_gameRepository.Delete(id);
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return RedirectToAction(nameof(Delete), new { id = id });
			}
		}

		// GET: GameController/Search
		public IActionResult Search(string searchQuery)
		{
			// Si la recherche est vide OU qu'aucun jeu spécifique n'est trouvé, on retourne tous les jeux
			if (string.IsNullOrEmpty(searchQuery))
			{
				var jeux = _gameRepository.Get()  // Récupère tous les jeux
							  .Select(bll => bll.ToListItem()); // Conversion en GameListItem (si nécessaire)
				return View("Index", jeux);  // Renvoyer à la vue Index avec tous les jeux
			}

			// Si une recherche est effectuée, on cherche les jeux correspondants
			var game = _gameRepository.Get()
							.FirstOrDefault(j => j.Nom.Contains(searchQuery, StringComparison.OrdinalIgnoreCase));

			// Si un jeu est trouvé, redirige vers la page de détails du jeu
			if (game != null)
			{
				return RedirectToAction("Details", new { id = game.JeuId });
			}

			// Si aucun jeu trouvé, afficher un message et rediriger vers l'index
			TempData["ErrorMessage"] = "Aucun jeu trouvé.";
			return RedirectToAction("Index");
		}
	}
}