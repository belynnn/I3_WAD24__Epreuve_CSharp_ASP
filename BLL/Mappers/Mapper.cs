﻿using System;
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
		#endregion

		#region GAME
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
				game.DateDesactivation
			);
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
	}
}