using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BLL.Entities
{
	//public enum UserRole { User, Admin }
	public class User
	{
		public int UtilisateurId { get; set; }
		public string Email { get; set; }
		public string MotDePasse { get; set; }
		public string Pseudo { get; set; }
		public DateTime DateCreation { get; set; }
		private DateTime? _dateDesactivation;
		//public string Role { get; set; }
		//public UserRole Role { get; set; }

		public bool IsDisabled
		{
			get { return _dateDesactivation is not null; }
		}

		// SI ROLE
		// public User(Guid userId, string pseudo, string email, string motDePasse, DateTime dateCreation, DateTime? _dateDesactivation, string role)
		public User(int utilisateurId, string pseudo, string email, string motDePasse, DateTime dateCreation, DateTime? _dateDesactivation)
		{
			UtilisateurId = utilisateurId;
			Pseudo = pseudo;
			Email = email;
			MotDePasse = motDePasse;
			DateCreation = dateCreation;
			_dateDesactivation = _dateDesactivation;
			//Role = Enum.Parse<UserRole>(role);
		}

		public User(string pseudo, string email, string motDePasse)
		{
			Pseudo = pseudo;
			Email = email;
			MotDePasse = motDePasse;
		}

		public User(string pseudo, string email)
		{
			Pseudo = pseudo;
			Email = email;
		}
	}
}