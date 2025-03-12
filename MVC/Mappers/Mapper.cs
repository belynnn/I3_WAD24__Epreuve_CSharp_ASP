using MVC.Models.User;
using BLL.Entities;

namespace MVC.Mappers
{
	internal static class Mapper
	{
		#region Users
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
	}
}