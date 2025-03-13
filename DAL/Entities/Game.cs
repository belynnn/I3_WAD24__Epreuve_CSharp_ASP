using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
	public class Game
	{
		public int JeuId { get; set; }
		public required string Nom { get; set; }
		public required string Description { get; set; }
		public int AgeMin { get; set; }
		public int AgeMax { get; set; }
		public int NbJoueurMin { get; set; }
		public int NbJoueurMax { get; set; }
		public int? DureeMinute { get; set; }
		public DateTime DateCreation { get; set; }
		public DateTime? DateDesactivation { get; set; }
	}
}