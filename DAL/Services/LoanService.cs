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
	public class LoanService : BaseService, ILoanRepository<DAL.Entities.Loan>
	//public class LoanService : ILoanRepository<DAL.Entities.Loan>
	{
		// ⚡Pour la suite
		public LoanService(IConfiguration config) : base(config, "Main-DB") { }
		// Pour DAL & BLL
		//private const string ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=DB-Debby-EpreuveASP;Integrated Security=True;";

		//// Récupérer TOP10 jeux empruntés
		//public IEnumerable<Loan> GetTop10MostRentedGames()
		//{
		//	var loans = new List<Loan>();

		//	using (SqlConnection connection = new SqlConnection(_connectionString))
		//	{
		//		using (SqlCommand command = connection.CreateCommand())
		//		{
		//			command.CommandText = "SP_Game_Top10_Emprunter";
		//			command.CommandType = CommandType.StoredProcedure;

		//			connection.Open();
		//			using (SqlDataReader reader = command.ExecuteReader())
		//			{
		//				while (reader.Read())
		//				{
		//					loans.Add(new Loan
		//					{
		//						JeuId = reader.GetInt32(reader.GetOrdinal("JeuId")),
		//						Nom = reader.GetString(reader.GetOrdinal("Nom")),
		//						Description = reader.GetString(reader.GetOrdinal("Description")),
		//						NombreEmprunts = reader.GetInt32(reader.GetOrdinal("NombreEmprunts"))
		//					});
		//				}
		//			}
		//		}
		//	}

		//	return loans;
		//}

		// Récupérer tous les emprunts
		public IEnumerable<Loan> Get()
		{
			using (SqlConnection connection = new SqlConnection(_connectionString))
			{
				using (SqlCommand command = connection.CreateCommand())
				{
					command.CommandText = "SP_Emprunt_GetAll"; // Exemple de procédure stockée
					command.CommandType = CommandType.StoredProcedure;
					connection.Open();
					using (SqlDataReader reader = command.ExecuteReader())
					{
						while (reader.Read())
						{
							yield return reader.ToLoan();
						}
					}
				}
			}
		}

		public IEnumerable<Loan> GetAll()
		{
			using (SqlConnection connection = new SqlConnection(_connectionString))
			{
				using (SqlCommand command = connection.CreateCommand())
				{
					command.CommandText = "SP_Emprunt_GetAll";
					command.CommandType = CommandType.StoredProcedure;
					connection.Open();
					using (SqlDataReader reader = command.ExecuteReader())
					{
						var loans = new List<Loan>();
						while (reader.Read())
						{
							loans.Add(reader.ToLoan());
						}
						return loans;
					}
				}
			}
		}

		// Récupérer tous les emprunts actifs
		public IEnumerable<Loan> GetAllActive()
		{
			using (SqlConnection connection = new SqlConnection(_connectionString))
			{
				using (SqlCommand command = connection.CreateCommand())
				{
					command.CommandText = "SP_Emprunt_GetAllActive"; // Exemple de procédure stockée
					command.CommandType = CommandType.StoredProcedure;
					connection.Open();
					using (SqlDataReader reader = command.ExecuteReader())
					{
						var loans = new List<Loan>();
						while (reader.Read())
						{
							loans.Add(reader.ToLoan());
						}
						return loans;
					}
				}
			}
		}

		// Récupérer un emprunt par son ID
		public Loan Get(int empruntId)
		{
			using (SqlConnection connection = new SqlConnection(_connectionString))
			{
				using (SqlCommand command = connection.CreateCommand())
				{
					command.CommandText = "SP_Emprunt_GetById"; // Exemple de procédure stockée
					command.CommandType = CommandType.StoredProcedure;
					command.Parameters.AddWithValue(nameof(empruntId), empruntId);
					connection.Open();
					using (SqlDataReader reader = command.ExecuteReader())
					{
						if (reader.Read())
						{
							return reader.ToLoan();
						}
						else
						{
							throw new ArgumentOutOfRangeException(nameof(empruntId));
						}
					}
				}
			}
		}

		// Insérer un emprunt
		public int Insert(Loan loan)
		{
			if (loan == null)
			{
				throw new ArgumentNullException(nameof(loan), "L'emprunt ne peut pas être nul.");
			}

			using (SqlConnection connection = new SqlConnection(_connectionString))
			{
				using (SqlCommand command = connection.CreateCommand())
				{
					command.CommandText = "SP_Emprunt_Insert"; // Exemple de procédure stockée
					command.CommandType = CommandType.StoredProcedure;

					command.Parameters.AddWithValue(nameof(Loan.JeuId), loan.JeuId);
					command.Parameters.AddWithValue(nameof(Loan.PreteurId), loan.PreteurId);
					command.Parameters.AddWithValue(nameof(Loan.EmprunteurId), loan.EmprunteurId);
					command.Parameters.AddWithValue(nameof(Loan.DateEmprunt), loan.DateEmprunt);
					command.Parameters.AddWithValue(nameof(Loan.DateRetour), (object?)loan.DateRetour ?? DBNull.Value);
					command.Parameters.AddWithValue(nameof(Loan.EvaluationPreteur), (object?)loan.EvaluationPreteur ?? DBNull.Value);
					command.Parameters.AddWithValue(nameof(Loan.EvaluationEmprunteur), (object?)loan.EvaluationEmprunteur ?? DBNull.Value);

					connection.Open();
					// Assurez-vous que la procédure stockée retourne l'ID de l'emprunt inséré
					return (int)command.ExecuteScalar();
				}
			}
		}

		// Mettre à jour un emprunt
		public void Update(int empruntId, Loan loan)
		{
			using (SqlConnection connection = new SqlConnection(_connectionString))
			{
				using (SqlCommand command = connection.CreateCommand())
				{
					command.CommandText = "SP_Emprunt_Update"; // Exemple de procédure stockée
					command.CommandType = CommandType.StoredProcedure;
					command.Parameters.AddWithValue(nameof(empruntId), empruntId);
					command.Parameters.AddWithValue(nameof(Loan.JeuId), loan.JeuId);
					command.Parameters.AddWithValue(nameof(Loan.PreteurId), loan.PreteurId);
					command.Parameters.AddWithValue(nameof(Loan.EmprunteurId), loan.EmprunteurId);
					command.Parameters.AddWithValue(nameof(Loan.DateEmprunt), loan.DateEmprunt);
					command.Parameters.AddWithValue(nameof(Loan.DateRetour), (object?)loan.DateRetour ?? DBNull.Value);
					command.Parameters.AddWithValue(nameof(Loan.EvaluationPreteur), (object?)loan.EvaluationPreteur ?? DBNull.Value);
					command.Parameters.AddWithValue(nameof(Loan.EvaluationEmprunteur), (object?)loan.EvaluationEmprunteur ?? DBNull.Value);

					connection.Open();
					command.ExecuteNonQuery();
				}
			}
		}

		// Supprimer un emprunt
		public void Delete(int empruntId)
		{
			using (SqlConnection connection = new SqlConnection(_connectionString))
			{
				using (SqlCommand command = connection.CreateCommand())
				{
					command.CommandText = "SP_Emprunt_Return"; // Exemple de procédure stockée
					command.CommandType = CommandType.StoredProcedure;
					command.Parameters.AddWithValue(nameof(empruntId), empruntId);
					connection.Open();
					command.ExecuteNonQuery();
				}
			}
		}
	}
}