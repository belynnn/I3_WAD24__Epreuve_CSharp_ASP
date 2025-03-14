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
	// Implémentation de l'interface IGameRepository avec des objets de type BLL
	public class GameService : IGameRepository<Game>
	{
		// Dépendance vers le repository de DAL
		private IGameRepository<D.Game> _gameRepository;

		// Constructeur
		public GameService(IGameRepository<D.Game> gameRepository)
		{
			_gameRepository = gameRepository;
		}

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

		// Top10 des jeux les plus empruntés
		public IEnumerable<Game> GetTop10MostRentedGames()
		{
			var top10Games = _gameRepository.GetTop10MostRentedGames();
			return top10Games.Select(dal => dal.ToBLL()); //
		}

		// Méthode pour rechercher des jeux
		public IEnumerable<Game> Search(string searchQuery)
		{
			// Recherche par nom de jeu uniquement
			return _gameRepository.Get()
				.Where(j => j.Nom.Contains(searchQuery, StringComparison.OrdinalIgnoreCase))
				.Select(dal => dal.ToBLL());
		}
	}
}