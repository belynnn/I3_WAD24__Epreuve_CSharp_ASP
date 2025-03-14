using BLL.Entities;
using BLL.Services;
using DE = DAL.Entities;
using D = DAL.Services;

namespace TestConsoleBLL
{
	internal class Program
	{
		static void Main(string[] args)
		{
			#region TEST BLL USER
			/*
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
			*/
			#endregion

			#region TEST BLL GAME
			/*
			Console.WriteLine("=== Début du test BLL pour Game ===\n");

			// Instanciation du GameService de la DAL
			var dalGameService = new D.GameService(); // Vérifie que ce nom correspond à ton DAL.GameService

			// Instanciation de la BLL avec la vraie DAL
			var gameService = new GameService(dalGameService);

			try
			{
				#region TEST GETBYID
				// 🔹 Test : Récupération d'un jeu par ID
				int testGameId = 1;  // Remplace par un ID valide existant dans ta base de données
				Console.WriteLine($"\nRécupération du jeu avec ID {testGameId}...");
				Game gameById = gameService.Get(testGameId);
				if (gameById != null)
				{
					Console.WriteLine($"Jeu trouvé : {gameById.Nom} - {gameById.Description}");
				}
				else
				{
					Console.WriteLine($"Jeu avec ID {testGameId} non trouvé.");
				}
				#endregion

				#region TEST GETALL
				// 🔹 Test : Récupération des jeux
				Console.WriteLine("\nListe de tous les jeux :");
				foreach (Game g in gameService.GetAll())
				{
					Console.WriteLine($"- {g.Nom}: {g.Description}");
				}
				#endregion

				#region TEST GETALLACTIVE
				// 🔹 Test : Récupération des jeux actifs
				Console.WriteLine("\nListe des jeux actifs :");
				foreach (Game g in gameService.GetAllActive())
				{
					Console.WriteLine($"- {g.Nom}: {g.Description}");
				}
				#endregion

				#region TEST INSERT
				// 🔹 Test : Insertion d'un nouveau jeu
				Console.WriteLine("\nAjout d'un nouveau jeu...");
				// Utilisation du constructeur sans JeuId, la base de données gérera ce champ
				Game newGame = new Game(0, "Monopoly", "Jeu de société classique", 8, 99, 2, 6, 60, DateTime.Now, null);
				int gameId = gameService.Insert(newGame);
				Console.WriteLine($"Jeu ajouté avec ID : {gameId}");

				// 🔹 Vérification de l'insertion
				Game foundGame = gameService.Get(gameId);
				Console.WriteLine($"Jeu trouvé : {foundGame.Nom} - {foundGame.Description}");
				#endregion

				#region TEST UPDATE
				// 🔹 Test : Modification d'un jeu
				Console.WriteLine("\nModification du jeu...");
				foundGame.Nom = "Monopoly Updated"; // Modifier le nom du jeu

				// Appeler la méthode de mise à jour
				gameService.Update(gameId, foundGame);

				// Vérification de la mise à jour
				Game updatedGame = gameService.Get(gameId);
				Console.WriteLine($"Jeu mis à jour : {updatedGame.Nom}");
				#endregion

				#region TEST DELETE (désactivation)
				// 🔹 Suppression pour nettoyer le test
				Console.WriteLine("\nDésactivation du test jeu...");
				gameService.Delete(gameId);
				Console.WriteLine("Jeu désactivé.");
				#endregion
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Erreur : {ex.Message}");
			}

			Console.WriteLine("\n=== Fin du test ===");
			Console.ReadLine();
			*/
			#endregion

			#region TEST BLL EMPRUNT
			Console.WriteLine("=== Début du test BLL pour Emprunt ===\n");

			// Instanciation du EmpruntService de la DAL
			var dalEmpruntService = new D.LoanService(); // Vérifie que ce nom correspond à ton DAL.EmpruntService

			// Instanciation de la BLL avec la vraie DAL
			var empruntService = new LoanService(dalEmpruntService);

			try
			{
				#region TEST GETBYID
				// 🔹 Test : Récupération d'un emprunt par ID
				int testEmpruntId = 1;  // Remplace par un ID valide existant dans ta base de données
				Console.WriteLine($"\nRécupération de l'emprunt avec ID {testEmpruntId}...");
				Loan empruntById = empruntService.Get(testEmpruntId);
				if (empruntById != null)
				{
					Console.WriteLine($"Emprunt trouvé : Jeu ID {empruntById.JeuId} ({empruntById.JeuNom}), Prêteur ID {empruntById.PreteurId}, Emprunteur ID {empruntById.EmprunteurId}, Date d'emprunt {empruntById.DateEmprunt}");
				}
				else
				{
					Console.WriteLine($"Emprunt avec ID {testEmpruntId} non trouvé.");
				}
				#endregion

				#region TEST GETALL
				// 🔹 Test : Récupération de tous les emprunts
				Console.WriteLine("\nListe de tous les emprunts :");
				foreach (Loan e in empruntService.GetAll())
				{
					Console.WriteLine($"- Emprunt {e.EmpruntId}: Jeu ID {e.JeuId} ({e.JeuNom}), Prêteur ID {e.PreteurId}, Emprunteur ID {e.EmprunteurId}, Date d'emprunt {e.DateEmprunt}");
				}
				#endregion

				#region TEST GETBYEMPRUNTEURID
				/*
				// 🔹 Test : Récupération des emprunts par ID emprunteur
				int testEmprunteurId = 1;  // Remplace par un ID valide d'emprunteur
				Console.WriteLine($"\nListe des emprunts pour l'emprunteur avec ID {testEmprunteurId}:");
				foreach (Loan e in empruntService.GetByEmprunteurId(testEmprunteurId))
				{
					Console.WriteLine($"- Emprunt {e.EmpruntId}: Jeu ID {e.JeuId}");
				}
				*/
				#endregion

				#region TEST INSERT
				// 🔹 Test : Insertion d'un nouvel emprunt
				Console.WriteLine("\nAjout d'un nouvel emprunt...");
				Loan newEmprunt = new Loan
				{
					JeuId = 1, // ID de jeu existant
					PreteurId = 1, // ID de prêteur existant
					EmprunteurId = 2, // ID d'emprunteur existant
					DateEmprunt = DateTime.Now,
					DateRetour = DateTime.Now.AddDays(7) // Emprunt de 7 jours
				};
				int empruntId = empruntService.Insert(newEmprunt);
				Console.WriteLine($"Emprunt ajouté avec ID : {empruntId}");

				// 🔹 Vérification de l'insertion
				Loan foundEmprunt = empruntService.Get(empruntId);
				Console.WriteLine($"Emprunt trouvé : Jeu ID {foundEmprunt.JeuId}, Prêteur ID {foundEmprunt.PreteurId}, Emprunteur ID {foundEmprunt.EmprunteurId}");
				#endregion

				#region TEST UPDATE
				// 🔹 Test : Modification d'un emprunt
				Console.WriteLine("\nModification de l'emprunt...");
				foundEmprunt.DateRetour = DateTime.Now.AddDays(14); // Prolonger la durée de l'emprunt

				// Appeler la méthode de mise à jour
				empruntService.Update(empruntId, foundEmprunt);

				// Vérification de la mise à jour
				Loan updatedEmprunt = empruntService.Get(empruntId);
				Console.WriteLine($"Emprunt mis à jour : Retour prévu pour {updatedEmprunt.DateRetour}");
				#endregion

				#region TEST DELETE
				// 🔹 Test : Suppression d'un emprunt
				Console.WriteLine("\nSuppression de l'emprunt...");
				empruntService.Delete(empruntId);
				Console.WriteLine("Emprunt supprimé.");
				#endregion
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Erreur : {ex.Message}");
			}

			Console.WriteLine("\n=== Fin du test ===");
			Console.ReadLine();
			#endregion
		}
	}
}