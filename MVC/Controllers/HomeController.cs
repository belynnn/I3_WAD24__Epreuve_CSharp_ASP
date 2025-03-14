using BLL.Services;
using Common.Repositories;
using Microsoft.AspNetCore.Mvc;
using MVC.Models;
using System.Diagnostics;

namespace MVC.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private readonly IGameRepository<BLL.Entities.Game> _gameService;

		public HomeController(ILogger<HomeController> logger, IGameRepository<BLL.Entities.Game> gameService)
		{
			_logger = logger;
			_gameService = gameService;
		}

		public IActionResult Index()
		{
			var games = _gameService.Get();
			return View(games);
		}

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
