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
	}
}
