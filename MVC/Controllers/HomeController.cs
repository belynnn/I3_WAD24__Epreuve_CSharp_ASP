using BLL.Services;
using Common.Repositories;
using DAL.Services;
using Microsoft.AspNetCore.Mvc;
using MVC.Models;
using System.Diagnostics;

namespace MVC.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private readonly IGameRepository<BLL.Entities.Game> _gameService;
		private readonly ILoanRepository<BLL.Entities.Loan> _loanService;

		public HomeController(ILogger<HomeController> logger, IGameRepository<BLL.Entities.Game> gameService, ILoanRepository<BLL.Entities.Loan> loanService)
		{
			_logger = logger;
			_loanService = loanService;
			_gameService = gameService;
		}

		public IActionResult Index()
		{
			var topGames = _gameService.GetTop10MostRentedGames();
			return View(topGames);
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