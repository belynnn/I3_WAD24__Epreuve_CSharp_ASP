using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
	public class Loan
	{
		public int EmpruntId { get; set; }
		public int JeuId { get; set; }
		public string JeuNom { get; set; }  // Ajout de la propriété JeuNom
		public int PreteurId { get; set; }
		public int EmprunteurId { get; set; }
		public DateTime DateEmprunt { get; set; }
		public DateTime? DateRetour { get; set; }
		public int? EvaluationPreteur { get; set; }
		public int? EvaluationEmprunteur { get; set; }
	}
}