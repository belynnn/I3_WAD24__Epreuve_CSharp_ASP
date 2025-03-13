using MVC.Models.User;
using BLL.Entities;
using MVC.Models.Game;

namespace MVC.Mappers
{
	internal static class Mapper
	{
		#region USER
		public static UserListItem ToListItem(this User user)
		{
			if (user is null) throw new ArgumentNullException(nameof(user));
			return new UserListItem()
			{
				UtilisateurId = user.UtilisateurId,
				Pseudo = user.Pseudo,
			};
		}

		public static UserDetails ToDetails(this User user)
		{
			if (user is null) throw new ArgumentNullException(nameof(user));
			return new UserDetails()
			{
				UtilisateurId = user.UtilisateurId,
				Pseudo = user.Pseudo,
				Email = user.Email,
				DateCreation = DateOnly.FromDateTime(user.DateCreation),
			};
		}

		public static User ToBLL(this UserCreateForm user)
		{
			if (user is null) throw new ArgumentNullException(nameof(user));
			return new User(
				0, // Utilisation de 0 comme valeur par défaut pour un int
				user.Pseudo,
				user.Email,
				user.MotDePasse,
				DateTime.Now,
				null
			);
		}

		public static UserEditForm ToEditForm(this User user)
		{
			if (user is null) throw new ArgumentNullException(nameof(user));
			return new UserEditForm()
			{
				UtilisateurId = user.UtilisateurId,
				Pseudo = user.Pseudo
			};
		}

		public static User ToBLL(this UserEditForm user)
		{
			if (user is null) throw new ArgumentNullException(nameof(user));
			return new User(
				user.Pseudo); // en lien avec entity user BLL
		}

		public static UserDelete ToDelete(this User user) // désactiver l'utilisateur
		{
			if (user is null) throw new ArgumentNullException(nameof(user));
			return new UserDelete()
			{
				UtilisateurId = user.UtilisateurId,
				Pseudo = user.Pseudo,
				Email = user.Email,
			};
		}
		#endregion

		#region GAME
		public static GameListItem ToListItem(this Game game)
		{
			if (game is null) throw new ArgumentNullException(nameof(game));
			return new GameListItem()
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
				IsDisabled = game.IsDisabled,
			};
		}

		public static GameDetails ToDetails(this Game game)
		{
			if (game is null) throw new ArgumentNullException(nameof(game));
			return new GameDetails()
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
				IsDisabled = game.IsDisabled
			};
		}

		public static Game ToBLL(this GameCreateForm game)
		{
			if (game is null) throw new ArgumentNullException(nameof(game));
			return new Game(
				0, // JeuId par défaut pour la création
				game.Nom,
				game.Description,
				game.AgeMin,
				game.AgeMax,
				game.NbJoueurMin,
				game.NbJoueurMax,
				game.DureeMinute,
				DateTime.Now,
				null // DateDesactivation est null pour un nouveau jeu
			);
		}

		public static GameEditForm ToEditForm(this Game game)
		{
			if (game is null) throw new ArgumentNullException(nameof(game));
			return new GameEditForm()
			{
				JeuId = game.JeuId,
				Nom = game.Nom,
				Description = game.Description,
				AgeMin = game.AgeMin,
				AgeMax = game.AgeMax,
				NbJoueurMin = game.NbJoueurMin,
				NbJoueurMax = game.NbJoueurMax,
				DureeMinute = game.DureeMinute,
			};
		}

		public static Game ToBLL(this GameEditForm game)
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
				DateTime.Now,
				null // DateDesactivation peut être null
			);
		}
		// Désactiver un jeu
		public static GameDelete ToDelete(this Game game)
		{
			if (game is null) throw new ArgumentNullException(nameof(game));
			return new GameDelete()
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
				IsDisabled = game.IsDisabled, // On retourne si le jeu est désactivé
			};
		}
		#endregion
	}
}