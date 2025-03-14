using Common.Repositories;
using DAL.Entities;
using DAL.Mappers;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Services
{
	public class UserService : BaseService, IUserRepository<DAL.Entities.User>
	{
		public UserService(IConfiguration config) : base(config, "Main-DB") { }
		public IEnumerable<User> Get()
		{
			using (SqlConnection connection = new SqlConnection(_connectionString))
			{
				using (SqlCommand command = connection.CreateCommand())
				{
					command.CommandText = "SP_Utilisateur_GetAllActive";
					command.CommandType = CommandType.StoredProcedure;
					connection.Open();
					using (SqlDataReader reader = command.ExecuteReader())
					{
						while (reader.Read())
						{
							yield return reader.ToUser();
						}
					}
				}
			}
		}

		public User Get(int user_id)
		{
			using (SqlConnection connection = new SqlConnection(_connectionString))
			{
				using (SqlCommand command = connection.CreateCommand())
				{
					command.CommandText = "SP_Utilisateur_GetById";
					command.CommandType = CommandType.StoredProcedure;
					// Ajouter le paramètre avec le bon nom (@UtilisateurId) de la procédure stockée
					command.Parameters.AddWithValue("@UtilisateurId", user_id); // Nom exact du paramètre

					connection.Open();
					using (SqlDataReader reader = command.ExecuteReader())
					{
						if (reader.Read())
						{
							return reader.ToUser();
						}
						else
						{
							throw new ArgumentOutOfRangeException(nameof(user_id));
						}
					}
				}
			}
		}

		public IEnumerable<User> GetAll()
		{
			using (SqlConnection connection = new SqlConnection(_connectionString))
			{
				using (SqlCommand command = connection.CreateCommand())
				{
					command.CommandText = "SP_Utilisateur_GetAll"; // Nom de la procédure stockée pour récupérer tous les utilisateurs
					command.CommandType = CommandType.StoredProcedure;
					connection.Open();
					using (SqlDataReader reader = command.ExecuteReader())
					{
						var users = new List<User>();
						while (reader.Read())
						{
							// Mappe chaque utilisateur récupéré depuis la base de données vers un objet User de BLL
							users.Add(reader.ToUser()); // Assure-toi que 'ToUser()' est une extension qui mappe le lecteur SQL vers un objet User
						}
						return users;
					}
				}
			}
		}

		public IEnumerable<User> GetAllActive()
		{
			using (SqlConnection connection = new SqlConnection(_connectionString))
			{
				using (SqlCommand command = connection.CreateCommand())
				{
					command.CommandText = "SP_Utilisateur_GetAllActive"; // Nom de la procédure stockée
					command.CommandType = CommandType.StoredProcedure;
					connection.Open();
					using (SqlDataReader reader = command.ExecuteReader())
					{
						var users = new List<User>();
						while (reader.Read())
						{
							// Mappe chaque utilisateur récupéré depuis la base de données vers un objet User de BLL
							users.Add(reader.ToUser()); // Assure-toi que 'ToUser()' est une extension qui mappe le lecteur SQL vers un objet User
						}
						return users;
					}
				}
			}
		}

		public int Insert(User user)
		{
			using (SqlConnection connection = new SqlConnection(_connectionString))
			{
				using (SqlCommand command = connection.CreateCommand())
				{
					command.CommandText = "SP_Utilisateur_Insert";
					command.CommandType = CommandType.StoredProcedure;
					command.Parameters.AddWithValue(nameof(User.Pseudo), user.Pseudo);
					command.Parameters.AddWithValue(nameof(User.Email), user.Email);
					command.Parameters.AddWithValue(nameof(User.MotDePasse), user.MotDePasse);
					connection.Open();
					return (int)command.ExecuteScalar();
				}
			}
		}

		public void Update(int user_id, User user)
		{
			using (SqlConnection connection = new SqlConnection(_connectionString))
			{
				using (SqlCommand command = connection.CreateCommand())
				{
					command.CommandText = "SP_Utilisateur_Update";
					command.CommandType = CommandType.StoredProcedure;
					command.Parameters.AddWithValue("@UtilisateurId", user_id);
					command.Parameters.AddWithValue("@NewPseudo", user.Pseudo);
					connection.Open();
					command.ExecuteNonQuery();
				}
			}
		}

		public void Delete(int user_id)
		{
			using (SqlConnection connection = new SqlConnection(_connectionString))
			{
				using (SqlCommand command = connection.CreateCommand())
				{
					command.CommandText = "SP_Utilisateur_Delete";
					command.CommandType = CommandType.StoredProcedure;

					command.Parameters.AddWithValue("@UtilisateurId", user_id); // Nom exact du paramètre
					connection.Open();
					command.ExecuteNonQuery();
				}
			}
		}

		public int CheckPassword(string email, string password)
		{
			using (SqlConnection connection = new SqlConnection(_connectionString))
			{
				using (SqlCommand command = connection.CreateCommand())
				{
					command.CommandText = "SP_Utilisateur_CheckPassword";
					command.CommandType = CommandType.StoredProcedure;
					command.Parameters.AddWithValue(nameof(email), email);
					command.Parameters.AddWithValue(nameof(password), password);
					connection.Open();
					return (int)command.ExecuteScalar();
				}
			}
		}
	}
}