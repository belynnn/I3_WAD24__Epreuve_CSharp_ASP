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
		public static User ToBLL(this D.User user)
		{
			if (user is null) throw new ArgumentNullException(nameof(user));
			return new User(
				user.UtilisateurId,
				user.Pseudo,
				user.Email,
				user.MotDePasse,
				user.DateCreation,
				user.DateDesactivation/*,
				user.Role*/);
		}

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
	}
}