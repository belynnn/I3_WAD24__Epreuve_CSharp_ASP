using BLL.Entities;
using BLL.Services;
using DAL.Entities;
using D = DAL.Services;

namespace TestConsoleBLL
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("=== Début du test BLL avec la vraie base de données ===\n");

			// Instanciation du UserService de la DAL
			var dalUserService = new D.UserService(); // Vérifie que ce nom correspond à ton DAL.UserService

			// Instanciation de la BLL avec la vraie DAL
			var userService = new UserService(dalUserService);

			try
			{
				#region TEST GETBYID
				// 🔹 Test : Récupération d'un utilisateur par ID
				int testUserId = 1;  // Remplace par un ID valide existant dans ta base de données
				Console.WriteLine($"\nRécupération de l'utilisateur avec ID {testUserId}...");
				BLL.Entities.User userById = userService.Get(testUserId);
				Console.WriteLine($"Utilisateur trouvé : {userById.Pseudo} ({userById.Email})");
				#endregion

				#region TEST GETALL
				// 🔹 Test : Récupération des utilisateurs actifs
				Console.WriteLine("Liste des utilisateurs (actifs et inactifs) :");
				foreach (BLL.Entities.User u in userService.GetAll())
				{
					Console.WriteLine($"- {u.Pseudo} : {u.Email}");
				}
				#endregion

				#region TEST GETALLACTIVE
				// 🔹 Test : Récupération des utilisateurs actifs
				Console.WriteLine("\nListe des utilisateurs (actifs) :");
				foreach (BLL.Entities.User u in userService.GetAllActive())
				{
					Console.WriteLine($"- {u.Pseudo} : {u.Email}");
				}
				#endregion

				#region TEST INSERT
				// 🔹 Test : Insertion d'un nouvel utilisateur
				Console.WriteLine("\nAjout d'un nouvel utilisateur...");
				BLL.Entities.User newUser = new BLL.Entities.User("Belynn", "belynn@mail.com", "azerty-12345");
				int userId = userService.Insert(newUser);
				Console.WriteLine($"Utilisateur ajouté avec ID : {userId}");

				// 🔹 Vérification de l'insertion
				BLL.Entities.User foundUser = userService.Get(userId);
				Console.WriteLine($"Utilisateur trouvé : {foundUser.Pseudo} ({foundUser.Email})");
				#endregion

				#region TEST UPDATE
				// 🔹 Test : Modification d'un utilisateur
				Console.WriteLine("\nModification de l'utilisateur...");
				foundUser.Pseudo = "BelynnUpdated"; // Modifier le pseudo

				// Appeler la méthode de mise à jour
				userService.Update(userId, foundUser);

				// Vérification de la mise à jour
				BLL.Entities.User updatedUser = userService.Get(userId);
				Console.WriteLine($"Utilisateur mis à jour : {updatedUser.Pseudo}");
				#endregion

				#region TEST DELETE
				// 🔹 Suppression pour nettoyer le test
				Console.WriteLine("\nSuppression du test utilisateur...");
				userService.Delete(userId);
				Console.WriteLine("Utilisateur supprimé.");
				#endregion
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Erreur : {ex.Message}");
			}

			Console.WriteLine("\n=== Fin du test ===");
			Console.ReadLine();
		}
	}
}