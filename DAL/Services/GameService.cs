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
	// ⚡Pour la suite
	//public class GameService : BaseService, IGameRepository<DAL.Entities.Game>
	public class GameService : IGameRepository<DAL.Entities.Game>
	{
		// ⚡Pour la suite
		//public UserService(IConfiguration config) : base(config, "Main-DB") { }
		// Pour DAL & BLL
		private const string ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=DB;Integrated Security=True;";

		public IEnumerable<Game> Get()
		{
			using (SqlConnection connection = new SqlConnection(ConnectionString))
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

		public IEnumerable<Game> GetAll()
		{
			using (SqlConnection connection = new SqlConnection(ConnectionString))
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

		public IEnumerable<Game> GetAllActive()
		{
			using (SqlConnection connection = new SqlConnection(ConnectionString))
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


		public Game Get(int jeuId)
		{
			using (SqlConnection connection = new SqlConnection(ConnectionString))
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

		public int Insert(Game game)
		{
			if (game == null)
			{
				throw new ArgumentNullException(nameof(game), "Le jeu ne peut pas être nul.");
			}

			using (SqlConnection connection = new SqlConnection(ConnectionString))
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
					// Assurez-vous que la procédure stockée retourne l'ID du jeu inséré
					return (int)command.ExecuteScalar();
				}
			}
		}

		public void Update(int jeuId, Game game)
		{
			using (SqlConnection connection = new SqlConnection(ConnectionString))
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
			using (SqlConnection connection = new SqlConnection(ConnectionString))
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
	}
}