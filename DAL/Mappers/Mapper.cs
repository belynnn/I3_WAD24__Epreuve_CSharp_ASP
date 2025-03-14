using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Mappers
{
	internal static class Mapper
	{
		#region USER
		public static User ToUser(this IDataRecord record)
		{
			if (record is null) throw new ArgumentNullException(nameof(record));

			return new User()
			{
				UtilisateurId = (int)record[nameof(User.UtilisateurId)],
				Email = (string)record[nameof(User.Email)],
				MotDePasse = "********",
				Pseudo = (string)record[nameof(User.Pseudo)],
				DateCreation = (DateTime)record[nameof(User.DateCreation)],
				DateDesactivation = (record[nameof(User.DateDesactivation)] is DBNull) ? null : (DateTime?)record[nameof(User.DateDesactivation)],
				//Role = (string)record[nameof(User.Role)]
			};
		}
		#endregion

		#region GAME
		public static Game ToGame(this IDataRecord record)
		{
			if (record is null) throw new ArgumentNullException(nameof(record));
			return new Game()
			{
				JeuId = (int)record[nameof(Game.JeuId)],
				Nom = (string)record[nameof(Game.Nom)],
				Description = (string)record[nameof(Game.Description)],
				AgeMin = (int)record[nameof(Game.AgeMin)],
				AgeMax = (int)record[nameof(Game.AgeMax)],
				NbJoueurMin = (int)record[nameof(Game.NbJoueurMin)],
				NbJoueurMax = (int)record[nameof(Game.NbJoueurMax)],
				DureeMinute = record[nameof(Game.DureeMinute)] is DBNull ? (int?)null : (int)record[nameof(Game.DureeMinute)],
				DateCreation = (DateTime)record[nameof(Game.DateCreation)],
				DateDesactivation = record[nameof(Game.DateDesactivation)] is DBNull ? (DateTime?)null : (DateTime)record[nameof(Game.DateDesactivation)]
			};
		}
		#endregion

		#region LOAN
		public static Loan ToLoan(this IDataRecord record)
		{
			if (record is null) throw new ArgumentNullException(nameof(record));

			return new Loan()
			{
				EmpruntId = (int)record[nameof(Loan.EmpruntId)],
				JeuId = (int)record[nameof(Loan.JeuId)],
				JeuNom = record["JeuNom"] as string, // Récupération du nom du jeu
				PreteurId = (int)record[nameof(Loan.PreteurId)],
				EmprunteurId = (int)record[nameof(Loan.EmprunteurId)],
				DateEmprunt = (DateTime)record[nameof(Loan.DateEmprunt)],
				DateRetour = record[nameof(Loan.DateRetour)] is DBNull ? null : (DateTime?)record[nameof(Loan.DateRetour)],
				EvaluationPreteur = record[nameof(Loan.EvaluationPreteur)] is DBNull ? null : (int?)record[nameof(Loan.EvaluationPreteur)],
				EvaluationEmprunteur = record[nameof(Loan.EvaluationEmprunteur)] is DBNull ? null : (int?)record[nameof(Loan.EvaluationEmprunteur)]
			};
		}
		#endregion
	}
}