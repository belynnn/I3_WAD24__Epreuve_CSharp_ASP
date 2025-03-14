using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Entities;
using D = DAL.Entities;

namespace BLL.Mappers
{
	internal static class Mapper
	{
		#region USER
		// Mapper de DAL vers BLL
		public static User ToBLL(this D.User user)
		{
			if (user is null) throw new ArgumentNullException(nameof(user));
			return new User(
				user.UtilisateurId,
				user.Pseudo,
				user.Email,
				user.MotDePasse,
				user.DateCreation,
				user.DateDesactivation);
		}

		// Mapper de BLL vers DAL
		public static D.User ToDAL(this User user)
		{
			if (user is null) throw new ArgumentNullException(nameof(user));
			return new D.User()
			{
				UtilisateurId = user.UtilisateurId,
				Pseudo = user.Pseudo,
				Email = user.Email,
				MotDePasse = user.MotDePasse,
				DateCreation = user.DateCreation,
				DateDesactivation = (user.IsDisabled) ? new DateTime() : null/*,
				Role = user.Role.ToString()*/
			};
		}
		#endregion

		#region GAME
		// Mapper de DAL vers BLL
		public static Game ToBLL(this D.Game game)
		{
			if (game is null) throw new ArgumentNullException(nameof(game));
			return new Game(
				game.JeuId,
				game.Nom,
				game.Description,
				game.AgeMin,
				game.AgeMax,
				game.NbJoueurMin,
				game.NbJoueurMax,
				game.DureeMinute,
				game.DateCreation,
				game.DateDesactivation)
			{
				NombreEmprunts = game.NombreEmprunts
			};
		}

		// Mapper de BLL vers DAL
		public static D.Game ToDAL(this Game game)
		{
			if (game is null) throw new ArgumentNullException(nameof(game));
			return new D.Game()
			{
				JeuId = game.JeuId,
				Nom = game.Nom,
				Description = game.Description,
				AgeMin = game.AgeMin,
				AgeMax = game.AgeMax,
				NbJoueurMin = game.NbJoueurMin,
				NbJoueurMax = game.NbJoueurMax,
				DureeMinute = game.DureeMinute,
				DateCreation = game.DateCreation,
				DateDesactivation = (game.IsDisabled) ? new DateTime() : null
			};
		}
		#endregion

		#region LOAN
		// Mapper de DAL vers BLL
		public static Loan ToBLL(this D.Loan loan)
		{
			if (loan is null) throw new ArgumentNullException(nameof(loan));
			return new Loan(
				loan.EmpruntId,
				loan.JeuId,
				loan.PreteurId,
				loan.EmprunteurId,
				loan.DateEmprunt,
				loan.DateRetour,
				loan.EvaluationPreteur,
				loan.EvaluationEmprunteur
			);
		}

		// Mapper de BLL vers DAL
		public static D.Loan ToDAL(this Loan loan)
		{
			if (loan is null) throw new ArgumentNullException(nameof(loan));
			return new D.Loan()
			{
				EmpruntId = loan.EmpruntId,
				JeuId = loan.JeuId,
				PreteurId = loan.PreteurId,
				EmprunteurId = loan.EmprunteurId,
				DateEmprunt = loan.DateEmprunt,
				DateRetour = loan.DateRetour,
				EvaluationPreteur = loan.EvaluationPreteur,
				EvaluationEmprunteur = loan.EvaluationEmprunteur
			};
		}
		#endregion
	}
}