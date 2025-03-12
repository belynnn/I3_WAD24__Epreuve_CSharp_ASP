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
	// ⚡Pour la suite
	// public class UserService : BaseService, IUserRepository<DAL.Entities.User>
	public class UserService : IUserRepository<DAL.Entities.User>
	{
		// ⚡Pour la suite
		// public UserService(IConfiguration config) : base(config, "Main-DB") { }
		private const string ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=WAD24-DemoASP-DB;Integrated Security=True;";
		public IEnumerable<User> Get()
		{
			// ⚡Pour la suite ⚡⚡⚡ modifier chaque _connectionString en ConnectionString
			// using (SqlConnection connection = new SqlConnection(_connectionString))
			using (SqlConnection connection = new SqlConnection(ConnectionString)) 
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

		public User Get(Guid user_id)
		{
			using (SqlConnection connection = new SqlConnection(ConnectionString))
			{
				using (SqlCommand command = connection.CreateCommand())
				{
					command.CommandText = "SP_Utilisateur_GetById";
					command.CommandType = CommandType.StoredProcedure;
					command.Parameters.AddWithValue(nameof(user_id), user_id);
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

		public Guid Insert(User user)
		{
			using (SqlConnection connection = new SqlConnection(ConnectionString))
			{
				using (SqlCommand command = connection.CreateCommand())
				{
					command.CommandText = "SP_Utilisateur_Insert";
					command.CommandType = CommandType.StoredProcedure;
					command.Parameters.AddWithValue(nameof(User.Pseudo), user.Pseudo);
					command.Parameters.AddWithValue(nameof(User.Email), user.Email);
					command.Parameters.AddWithValue(nameof(User.MotDePasse), user.MotDePasse);
					connection.Open();
					return (Guid)command.ExecuteScalar();
				}
			}
		}

		public void Update(Guid user_id, User user)
		{
			using (SqlConnection connection = new SqlConnection(ConnectionString))
			{
				using (SqlCommand command = connection.CreateCommand())
				{
					command.CommandText = "SP_Utilisateur_Update";
					command.CommandType = CommandType.StoredProcedure;
					command.Parameters.AddWithValue(nameof(user_id), user_id);
					command.Parameters.AddWithValue(nameof(User.Pseudo), user.Pseudo);
					command.Parameters.AddWithValue(nameof(User.Email), user.Email);
					command.Parameters.AddWithValue(nameof(User.Email), user.Email);
					connection.Open();
					command.ExecuteNonQuery();
				}
			}
		}

		public void Delete(Guid user_id)
		{
			using (SqlConnection connection = new SqlConnection(ConnectionString))
			{
				using (SqlCommand command = connection.CreateCommand())
				{
					command.CommandText = "SP_Utilisateur_Delete";
					command.CommandType = CommandType.StoredProcedure;
					command.Parameters.AddWithValue(nameof(user_id), user_id);
					connection.Open();
					command.ExecuteNonQuery();
				}
			}
		}

		/*
		public Guid CheckPassword(string email, string password)
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
					return (Guid)command.ExecuteScalar();
				}
			}
		}
		*/
	}
}