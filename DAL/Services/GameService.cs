using Common.Repositories;
using DAL.Entities;
using DAL.Mappers;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;

namespace DAL.Services
{
	// Implémentation de l'interface IGameRepository
	public class GameService : BaseService, IGameRepository<DAL.Entities.Game>

	{
		// Chaîne de connexion à la base de données
		public GameService(IConfiguration config) : base(config, "Main-DB") { }

		// Méthode pour obtenir les 10 jeux les plus empruntés
		public IEnumerable<Game> GetTop10MostRentedGames()
		{
			var games = new List<Game>();

			using (SqlConnection connection = new SqlConnection(_connectionString))
			{
				using (SqlCommand command = connection.CreateCommand())
				{
					command.CommandText = "SP_Game_Top10_Emprunter";
					command.CommandType = CommandType.StoredProcedure;

					connection.Open();
					using (SqlDataReader reader = command.ExecuteReader())
					{
						while (reader.Read())
						{
							games.Add(new Game
							{
								JeuId = reader.GetInt32(reader.GetOrdinal("JeuId")),
								Nom = reader.GetString(reader.GetOrdinal("Nom")),
								Description = reader.GetString(reader.GetOrdinal("Description")),
								NombreEmprunts = reader.GetInt32(reader.GetOrdinal("NombreEmprunts"))
							});
						}
					}
				}
			}

			// Retourner la liste des jeux, même si elle est vide
			return games;
		}

		// Méthode pour obtenir tous les jeux
		public IEnumerable<Game> Get()
		{
			using (SqlConnection connection = new SqlConnection(_connectionString))
			{
				using (SqlCommand command = connection.CreateCommand())
				{
					command.CommandText = "SP_Jeu_GetAll";
					command.CommandType = CommandType.StoredProcedure;
					connection.Open();
					using (SqlDataReader reader = command.ExecuteReader())
					{
						while (reader.Read())
						{
							yield return reader.ToGame();
						}
					}
				}
			}
		}

		// Méthode pour obtenir tous les jeux
		public IEnumerable<Game> GetAll()
		{
			using (SqlConnection connection = new SqlConnection(_connectionString))
			{
				using (SqlCommand command = connection.CreateCommand())
				{
					command.CommandText = "SP_Jeu_GetAll";
					command.CommandType = CommandType.StoredProcedure;
					connection.Open();
					using (SqlDataReader reader = command.ExecuteReader())
					{
						var games = new List<Game>();
						while (reader.Read())
						{
							games.Add(reader.ToGame());
						}
						return games;
					}
				}
			}
		}

		// Méthode pour obtenir tous les jeux actifs
		public IEnumerable<Game> GetAllActive()
		{
			using (SqlConnection connection = new SqlConnection(_connectionString))
			{
				using (SqlCommand command = connection.CreateCommand())
				{
					command.CommandText = "SP_Jeu_GetAllActive";
					command.CommandType = CommandType.StoredProcedure;
					connection.Open();
					using (SqlDataReader reader = command.ExecuteReader())
					{
						var games = new List<Game>();
						while (reader.Read())
						{
							games.Add(reader.ToGame());
						}
						return games;
					}
				}
			}
		}

		// Méthode pour obtenir un jeu par ID
		public Game Get(int jeuId)
		{
			using (SqlConnection connection = new SqlConnection(_connectionString))
			{
				using (SqlCommand command = connection.CreateCommand())
				{
					command.CommandText = "SP_Jeu_GetById";
					command.CommandType = CommandType.StoredProcedure;
					command.Parameters.AddWithValue(nameof(jeuId), jeuId);
					connection.Open();
					using (SqlDataReader reader = command.ExecuteReader())
					{
						if (reader.Read())
						{
							return reader.ToGame();
						}
						else
						{
							throw new ArgumentOutOfRangeException(nameof(jeuId));
						}
					}
				}
			}
		}

		// Méthode pour insérer un jeu
		public int Insert(Game game)
		{
			if (game == null)
			{
				throw new ArgumentNullException(nameof(game), "Le jeu ne peut pas être nul.");
			}

			using (SqlConnection connection = new SqlConnection(_connectionString))
			{
				using (SqlCommand command = connection.CreateCommand())
				{
					command.CommandText = "SP_Jeu_Insert";
					command.CommandType = CommandType.StoredProcedure;

					command.Parameters.AddWithValue(nameof(Game.Nom), string.IsNullOrEmpty(game.Nom) ? throw new ArgumentNullException(nameof(game.Nom), "Le nom du jeu ne peut pas être nul ou vide.") : game.Nom);
					command.Parameters.AddWithValue(nameof(Game.Description), string.IsNullOrEmpty(game.Description) ? throw new ArgumentNullException(nameof(game.Description), "La description du jeu ne peut pas être vide.") : game.Description);
					command.Parameters.AddWithValue(nameof(Game.AgeMin), game.AgeMin);
					command.Parameters.AddWithValue(nameof(Game.AgeMax), game.AgeMax);
					command.Parameters.AddWithValue(nameof(Game.NbJoueurMin), game.NbJoueurMin);
					command.Parameters.AddWithValue(nameof(Game.NbJoueurMax), game.NbJoueurMax);
					command.Parameters.AddWithValue(nameof(Game.DureeMinute), (object?)game.DureeMinute ?? DBNull.Value);

					connection.Open();
					return (int)command.ExecuteScalar();
				}
			}
		}

		// Méthode pour mettre à jour un jeu
		public void Update(int jeuId, Game game)
		{
			using (SqlConnection connection = new SqlConnection(_connectionString))
			{
				using (SqlCommand command = connection.CreateCommand())
				{
					command.CommandText = "SP_Jeu_Update";
					command.CommandType = CommandType.StoredProcedure;
					command.Parameters.AddWithValue(nameof(jeuId), jeuId);
					command.Parameters.AddWithValue(nameof(Game.Nom), game.Nom);
					command.Parameters.AddWithValue(nameof(Game.Description), (object?)game.Description ?? DBNull.Value);
					command.Parameters.AddWithValue(nameof(Game.AgeMin), game.AgeMin);
					command.Parameters.AddWithValue(nameof(Game.AgeMax), game.AgeMax);
					command.Parameters.AddWithValue(nameof(Game.NbJoueurMin), game.NbJoueurMin);
					command.Parameters.AddWithValue(nameof(Game.NbJoueurMax), game.NbJoueurMax);
					command.Parameters.AddWithValue(nameof(Game.DureeMinute), (object?)game.DureeMinute ?? DBNull.Value);

					connection.Open();
					command.ExecuteNonQuery();
				}
			}
		}

		// Désactiver un jeu
		public void Delete(int jeuId)
		{
			using (SqlConnection connection = new SqlConnection(_connectionString))
			{
				using (SqlCommand command = connection.CreateCommand())
				{
					command.CommandText = "SP_Jeu_Delete";
					command.CommandType = CommandType.StoredProcedure;
					command.Parameters.AddWithValue(nameof(jeuId), jeuId);
					connection.Open();
					command.ExecuteNonQuery();
				}
			}
		}

		// Méthode pour rechercher un jeu par nom
		public IEnumerable<Game> Search(string searchTerm)
		{
			using (SqlConnection connection = new SqlConnection(_connectionString))
			{
				using (SqlCommand command = connection.CreateCommand())
				{
					// Requête SQL pour rechercher les jeux par nom (utilisation de LIKE)
					command.CommandText = "SELECT * FROM Jeux WHERE Nom LIKE @searchTerm";
					command.CommandType = CommandType.Text;
					command.Parameters.AddWithValue("@searchTerm", "%" + searchTerm + "%");

					connection.Open();
					using (SqlDataReader reader = command.ExecuteReader())
					{
						while (reader.Read())
						{
							// Conversion de la ligne en objet Game et retour de l'objet via yield
							yield return new Game
							{
								JeuId = reader.GetInt32(reader.GetOrdinal("Jeu_Id")),
								Nom = reader.GetString(reader.GetOrdinal("Nom")),
								Description = reader.GetString(reader.GetOrdinal("Description"))
							};
						}
					}
				}
			}
		}
	}
}