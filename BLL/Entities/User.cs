using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BLL.Entities
{
	public class User
	{
		public int UtilisateurId { get; set; }
		public string Email { get; set; }
		public string MotDePasse { get; set; }
		public string Pseudo { get; set; }
		public DateTime DateCreation { get; set; }
		private DateTime? _dateDesactivation;

		public bool IsDisabled
		{
			get { return _dateDesactivation is not null; }
		}

		public User(int utilisateurId, string pseudo, string email, string motDePasse, DateTime dateCreation, DateTime? dateDesactivation)
		{
			UtilisateurId = utilisateurId;
			Pseudo = pseudo;
			Email = email;
			MotDePasse = motDePasse;
			DateCreation = dateCreation;
			_dateDesactivation = dateDesactivation;
		}

		public User(string pseudo, string email, string motDePasse)
		{
			Pseudo = pseudo;
			Email = email;
			MotDePasse = motDePasse;
		}

		public User(string pseudo)
		{
			Pseudo = pseudo;
		}
	}
}