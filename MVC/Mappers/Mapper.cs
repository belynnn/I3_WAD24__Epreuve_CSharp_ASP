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
				Guid.Empty,
				user.First_Name,
				user.Last_Name,
				user.Email,
				user.Password,
				DateTime.Now,
				null,
				"User"
				);
			/*return new User(
                user.First_Name,
                user.Last_Name,
                user.Email,
                user.Password);*/
		}

		public static UserEditForm ToEditForm(this User user)
		{
			if (user is null) throw new ArgumentNullException(nameof(user));
			return new UserEditForm()
			{
				First_Name = user.First_Name,
				Last_Name = user.Last_Name,
				Email = user.Email
			};
		}

		public static User ToBLL(this UserEditForm user)
		{
			if (user is null) throw new ArgumentNullException(nameof(user));
			/*return new User(
                Guid.Empty,
                user.First_Name,
                user.Last_Name,
                user.Email,
                "********",
                DateTime.Now,
                null,
                "User"
                );*/
			return new User(
				user.First_Name,
				user.Last_Name,
				user.Email);
		}

		public static UserDelete ToDelete(this User user)
		{
			if (user is null) throw new ArgumentNullException(nameof(user));
			return new UserDelete()
			{
				First_Name = user.First_Name,
				Last_Name = user.Last_Name,
				Email = user.Email
			};
		}
		#endregion
	}
}
