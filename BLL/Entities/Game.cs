using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Entities
{
	public class Game
	{
		public int JeuId { get; set; }
		public string Nom { get; set; }
		public string Description { get; set; }
		public int AgeMin { get; set; }
		public int AgeMax { get; set; }
		public int NbJoueurMin { get; set; }
		public int NbJoueurMax { get; set; }
		public int? DureeMinute { get; set; }
		public DateTime DateCreation { get; set; }
		private DateTime? _dateDesactivation;

		// Propriété qui retourne un booléen indiquant si le jeu est désactivé
		public bool IsDisabled
		{
			get { return _dateDesactivation is not null; }
		}

		// Constructeur principal avec une DateDesactivation nullable
		public Game(int jeuId, string nom, string description, int ageMin, int ageMax, int nbJoueurMin, int nbJoueurMax, int? dureeMinute, DateTime dateCreation, DateTime? dateDesactivation)
		{
			JeuId = jeuId;
			Nom = nom;
			Description = description;
			AgeMin = ageMin;
			AgeMax = ageMax;
			NbJoueurMin = nbJoueurMin;
			NbJoueurMax = nbJoueurMax;
			DureeMinute = dureeMinute;
			DateCreation = dateCreation;
			_dateDesactivation = dateDesactivation;
		}

		// Constructeur pour créer un jeu actif sans DateDesactivation
		public Game(int jeuId, string nom, string description, int ageMin, int ageMax, int nbJoueurMin, int nbJoueurMax, int? dureeMinute)
			: this(jeuId, nom, description, ageMin, ageMax, nbJoueurMin, nbJoueurMax, dureeMinute, DateTime.Now)  // Default DateCreation
		{
		}

		// Constructeur pour un jeu désactivé
		public Game(int jeuId, string nom, string description, int ageMin, int ageMax, int nbJoueurMin, int nbJoueurMax, int? dureeMinute, DateTime dateCreation)
			: this(jeuId, nom, description, ageMin, ageMax, nbJoueurMin, nbJoueurMax, dureeMinute, dateCreation, null)
		{
		}
	}
}
