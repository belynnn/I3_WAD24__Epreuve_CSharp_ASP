using DAL.Entities;
using DAL.Services;

namespace TestConsoleDAL
{
	internal class Program
	{
		static void Main(string[] args)
		{
			#region TEST DAL USER
			/*
			*
			*
			Console.WriteLine("=== Début du test DAL (UserService) avec la vraie base de données ===\n");

			// Instanciation du UserService de la DAL
			var userService = new UserService();

			try
			{
				#region TEST GETBYID
				// 🔹 Test : Récupération d'un utilisateur par ID
				int testUserId = 1;  // Remplace par un ID valide existant dans ta base
				Console.WriteLine($"\nRécupération de l'utilisateur avec ID {testUserId}...");
				User userById = userService.Get(testUserId);
				Console.WriteLine($"Utilisateur trouvé : {userById.Pseudo} ({userById.Email})");
				#endregion

				#region TEST GETALL
				// 🔹 Test : Récupération de tous les utilisateurs (actifs et inactifs)
				Console.WriteLine("\nListe des utilisateurs (tous) :");
				foreach (User u in userService.GetAll())
				{
					Console.WriteLine($"- {u.Pseudo} : {u.Email}");
				}
				#endregion

				#region TEST GETALLACTIVE
				// 🔹 Test : Récupération des utilisateurs actifs
				Console.WriteLine("\nListe des utilisateurs (actifs) :");
				foreach (User u in userService.GetAllActive())
				{
					Console.WriteLine($"- {u.Pseudo} : {u.Email}");
				}
				#endregion

				#region TEST INSERT
				// 🔹 Test : Insertion d'un nouvel utilisateur
				Console.WriteLine("\nAjout d'un nouvel utilisateur...");
				User newUser = new User
				{
					Pseudo = "NouveauUser",
					Email = "nouveau@mail.com",
					MotDePasse = "azerty123" // À hasher dans un vrai projet
				};
				int userId = userService.Insert(newUser);
				Console.WriteLine($"Utilisateur ajouté avec ID : {userId}");

				// 🔹 Vérification de l'insertion
				User foundUser = userService.Get(userId);
				Console.WriteLine($"Utilisateur trouvé : {foundUser.Pseudo} ({foundUser.Email})");
				#endregion

				#region TEST UPDATE
				// 🔹 Test : Modification d'un utilisateur
				Console.WriteLine("\nModification de l'utilisateur...");
				foundUser.Pseudo = "PseudoModifié";

				// Appeler la méthode de mise à jour
				userService.Update(userId, foundUser);

				// Vérification de la mise à jour
				User updatedUser = userService.Get(userId);
				Console.WriteLine($"Utilisateur mis à jour : {updatedUser.Pseudo}");
				#endregion

				#region TEST DELETE
				// 🔹 Suppression pour nettoyer le test
				Console.WriteLine("\nSuppression du test utilisateur...");
				userService.Delete(userId);
				Console.WriteLine("Utilisateur supprimé.");
				#endregion

				#region TEST CHECKPASSWORD
				// 🔹 Test : Vérification du mot de passe
				Console.WriteLine("\nVérification du mot de passe...");
				string email = "test@mail.com"; // Remplace par un email valide
				string password = "motdepasse"; // Remplace par un mot de passe correct

				int checkResult = userService.CheckPassword(email, password);
				if (checkResult > 0)
					Console.WriteLine($"✅ Mot de passe correct pour l'utilisateur ID {checkResult}");
				else
					Console.WriteLine("❌ Email ou mot de passe incorrect.");
				#endregion
			}
			catch (Exception ex)
			{
				Console.WriteLine($"❌ Erreur : {ex.Message}");
			}

			Console.WriteLine("\n=== Fin du test ===");
			Console.ReadLine();
			*
			*
			*/
			#endregion

			#region TEST DAL GAME
			/*
			Console.WriteLine("=== Début du test DAL (GameService) avec la vraie base de données ===\n");

			// Instanciation du GameService de la DAL
			var gameService = new GameService();

			try
			{
				#region TEST GETBYID
				// 🔹 Test : Récupération d'un jeu par ID
				int testGameId = 1;  // Remplace par un ID valide existant dans ta base
				Console.WriteLine($"\nRécupération du jeu avec ID {testGameId}...");
				Game gameById = gameService.Get(testGameId);
				Console.WriteLine($"Jeu trouvé : {gameById.Nom} ({gameById.Description})");
				#endregion

				#region TEST GETALL
				// 🔹 Test : Récupération de tous les jeux (actifs et inactifs)
				Console.WriteLine("\nListe des jeux (tous) :");
				foreach (Game g in gameService.GetAll())
				{
					Console.WriteLine($"- {g.Nom} : {g.Description}");
				}
				#endregion

				#region TEST GETALLACTIVE
				// 🔹 Test : Récupération des jeux actifs
				Console.WriteLine("\nListe des jeux (actifs) :");
				foreach (Game g in gameService.GetAllActive())
				{
					Console.WriteLine($"- {g.Nom} : {g.Description}");
				}
				#endregion

				#region TEST INSERT
				// 🔹 Test : Insertion d'un nouveau jeu
				Console.WriteLine("\nAjout d'un nouveau jeu...");
				Game newGame = new Game
				{
					Nom = "Catan",
					Description = "Un jeu de stratégie et de gestion de ressources.",
					AgeMin = 10,
					AgeMax = 99,
					NbJoueurMin = 3,
					NbJoueurMax = 4,
					DureeMinute = 90,
				};
				int gameId = gameService.Insert(newGame);
				Console.WriteLine($"Jeu ajouté avec ID : {gameId}");

				// 🔹 Vérification de l'insertion
				Game foundGame = gameService.Get(gameId);
				Console.WriteLine($"Jeu trouvé : {foundGame.Nom} ({foundGame.Description})");
				#endregion

				#region TEST UPDATE
				// 🔹 Test : Modification d'un jeu
				Console.WriteLine("\nModification du jeu...");
				foundGame.Description = "Version améliorée du jeu avec une extension.";

				// Appeler la méthode de mise à jour
				gameService.Update(gameId, foundGame);

				// Vérification de la mise à jour
				Game updatedGame = gameService.Get(gameId);
				Console.WriteLine($"Jeu mis à jour : {updatedGame.Nom} - {updatedGame.Description}");
				#endregion

				#region TEST DELETE
				// 🔹 Suppression pour nettoyer le test
				Console.WriteLine("\nSuppression du test jeu...");
				gameService.Delete(gameId);
				Console.WriteLine("Jeu supprimé.");
				#endregion
			}
			catch (Exception ex)
			{
				Console.WriteLine($"❌ Erreur : {ex.Message}");
			}

			Console.WriteLine("\n=== Fin du test ===");
			Console.ReadLine();
			*/
			#endregion

			#region TEST DAL LOAN
			Console.WriteLine("=== Début du test DAL (LoanService) avec la vraie base de données ===\n");

			// Instanciation du LoanService de la DAL
			var loanService = new LoanService();

			try
			{
				#region TEST GETBYID
				// 🔹 Test : Récupération d'un emprunt par ID
				int testLoanId = 1;  // Remplace par un ID valide existant dans ta base
				Console.WriteLine($"\nRécupération de l'emprunt avec ID {testLoanId}...");
				Loan loanById = loanService.Get(testLoanId);
				Console.WriteLine($"Emprunt trouvé : Jeu ID {loanById.JeuId}, Emprunteur ID {loanById.EmprunteurId}");
				#endregion

				#region TEST GETALL
				// 🔹 Test : Récupération de tous les emprunts (actifs et inactifs)
				Console.WriteLine("\nListe des emprunts (tous) :");
				foreach (Loan l in loanService.GetAll())
				{
					Console.WriteLine($"- Jeu ID {l.JeuId}, Emprunteur ID {l.EmprunteurId}");
				}
				#endregion

				#region TEST GETALLACTIVE
				// 🔹 Test : Récupération des emprunts actifs
				Console.WriteLine("\nListe des emprunts actifs :");
				foreach (Loan l in loanService.GetAllActive())
				{
					Console.WriteLine($"- Jeu ID {l.JeuId}, Emprunteur ID {l.EmprunteurId}");
				}
				#endregion

				#region TEST INSERT
				// 🔹 Test : Insertion d'un nouvel emprunt
				Console.WriteLine("\nAjout d'un nouvel emprunt...");
				Loan newLoan = new Loan
				{
					JeuId = 2,           // Remplacer par un jeu valide existant
					PreteurId = 1,       // Remplacer par un préteur valide
					EmprunteurId = 2,    // Remplacer par un emprunteur valide
					DateEmprunt = DateTime.Now,
					DateRetour = DateTime.Now.AddDays(7),
					EvaluationPreteur = 2,
					EvaluationEmprunteur = 3
				};
				int loanId = loanService.Insert(newLoan);
				Console.WriteLine($"Emprunt ajouté avec ID : {loanId}");

				// 🔹 Vérification de l'insertion
				Loan foundLoan = loanService.Get(loanId);
				Console.WriteLine($"Emprunt trouvé : Jeu ID {foundLoan.JeuId}, Emprunteur ID {foundLoan.EmprunteurId}");
				#endregion

				#region TEST UPDATE
				// 🔹 Test : Modification d'un emprunt
				Console.WriteLine("\nModification de l'emprunt...");
				loanById.EvaluationPreteur = 5;

				// Appeler la méthode de mise à jour
				loanService.Update(testLoanId, loanById);

				// Vérification de la mise à jour
				Loan updatedLoan = loanService.Get(testLoanId);
				Console.WriteLine($"Emprunt mis à jour : Évaluation du préteur {updatedLoan.EvaluationPreteur}");
				#endregion

				#region TEST DELETE
				// 🔹 Suppression pour nettoyer le test
				Console.WriteLine("\nDésactivation du test emprunt...");
				loanService.Delete(testLoanId);
				Console.WriteLine("Emprunt désactivé.");
				#endregion

				#region TEST TOP 10 MOST RENTED GAMES
				// 🔹 Test : Récupération du Top 10 des jeux les plus empruntés
				Console.WriteLine("\nRécupération du Top 10 des jeux les plus empruntés...");
				var topGames = loanService.GetTop10MostRentedGames();
				Console.WriteLine("Top 10 des jeux les plus empruntés :");
				foreach (var game in topGames)
				{
					Console.WriteLine($"Jeu ID {game.JeuId}, Nom : {game.Nom}, Description : {game.Description} Nombre d'emprunts : {game.NombreEmprunts}");
				}
				#endregion
			}
			catch (Exception ex)
			{
				Console.WriteLine($"❌ Erreur : {ex.Message}");
			}

			Console.WriteLine("\n=== Fin du test ===");
			Console.ReadLine();
			#endregion
		}
	}
}