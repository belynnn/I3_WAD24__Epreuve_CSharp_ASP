using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
	public class User
	{
		public int UtilisateurId { get; set; }
		public required string Email { get; set; }
		public required string MotDePasse { get; set; }
		public required string Pseudo { get; set; }
		public DateTime DateCreation { get; set; }
		public DateTime? DateDesactivation { get; set; }
		//public string Role { get; set; }
	}
}