using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Entities
{
	public class Loan
	{
		public int EmpruntId { get; set; }
		public int JeuId { get; set; }
		public string JeuNom { get; set; }
		public int PreteurId { get; set; }
		public int EmprunteurId { get; set; }
		public DateTime DateEmprunt { get; set; }
		public DateTime? DateRetour { get; set; }
		public int? EvaluationPreteur { get; set; }
		public int? EvaluationEmprunteur { get; set; }

		// Propriétés de navigation (par exemple, pour accéder aux jeux et utilisateurs associés)
		public Game Game { get; set; }
		public User Preteur { get; set; }
		public User Emprunteur { get; set; }

		// Constructeur sans paramètres pour l'initialisation de l'entité
		public Loan() { }

		// Constructeur avec paramètres pour initialiser l'entité
		public Loan(int empruntId, int jeuId, int preteurId, int emprunteurId, DateTime dateEmprunt, DateTime? dateRetour, int? evaluationPreteur, int? evaluationEmprunteur)
		{
			EmpruntId = empruntId;
			JeuId = jeuId;
			PreteurId = preteurId;
			EmprunteurId = emprunteurId;
			DateEmprunt = dateEmprunt;
			DateRetour = dateRetour;
			EvaluationPreteur = evaluationPreteur;
			EvaluationEmprunteur = evaluationEmprunteur;
		}
	}
}