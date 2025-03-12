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
	}
}