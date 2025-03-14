using BLL.Entities;
using BLL.Mappers;
using D = DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Repositories;
using DAL.Services;

namespace BLL.Services
{
	public class GameService : IGameRepository<Game>
	{
		private IGameRepository<D.Game> _gameRepository;

		public GameService(IGameRepository<D.Game> gameRepository)
		{
			_gameRepository = gameRepository;
		}

		//public IEnumerable<Game> GetTop10MostRentedGames()
		//{
		//	// Récupère les 10 jeux les plus empruntés en appelant la méthode de la DAL
		//	var games = _gameRepository.GetTop10MostRentedGames();

		//	// Mapper les résultats DAL vers BLL et ajouter la propriété NombreEmprunts
		//	return games.Select(dal => dal.ToBLL());
		//}

		// Récupérer tous les jeux
		public IEnumerable<Game> Get()
		{
			return _gameRepository.Get().Select(dal => dal.ToBLL());
		}

		// Récupérer tous les jeux (y compris ceux désactivés)
		public IEnumerable<Game> GetAll()
		{
			return _gameRepository.GetAll().Select(dal => dal.ToBLL());
		}

		// Récupérer les jeux actifs (non désactivés)
		public IEnumerable<Game> GetAllActive()
		{
			return _gameRepository.GetAllActive().Select(dal => dal.ToBLL());
		}

		// Récupérer un jeu par son identifiant
		public Game Get(int gameId)
		{
			Game game = _gameRepository.Get(gameId).ToBLL();
			return game;
		}

		// Insérer un jeu dans la base de données
		public int Insert(Game game)
		{
			return _gameRepository.Insert(game.ToDAL());
		}

		// Mettre à jour un jeu
		public void Update(int gameId, Game game)
		{
			_gameRepository.Update(gameId, game.ToDAL());
		}

		// Supprimer un jeu
		public void Delete(int gameId)
		{
			_gameRepository.Delete(gameId);
		}

		public IEnumerable<Game> GetTop10MostRentedGames()
		{
			var top10Games = _gameRepository.GetTop10MostRentedGames(); // This calls the DAL method
			return top10Games.Select(dal => dal.ToBLL()); // Assuming you have a ToBLL() extension method to map DAL entities to BLL entities
		}

		// Méthode pour rechercher des jeux
		public IEnumerable<Game> Search(string searchQuery)
		{
			// Si la recherche est vide, on retourne tous les jeux
			if (string.IsNullOrEmpty(searchQuery))
			{
				return _gameRepository.Get().Select(dal => dal.ToBLL());
			}

			// Recherche par nom de jeu uniquement
			return _gameRepository.Get()
				.Where(j => j.Nom.Contains(searchQuery, StringComparison.OrdinalIgnoreCase))
				.Select(dal => dal.ToBLL());
		}
	}
}
