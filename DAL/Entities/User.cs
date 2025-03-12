using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
	public class User
	{
		public Guid UtilisateurId { get; set; }
		public string Email { get; set; }
		public string MotDePasse { get; set; }
		public string Pseudo { get; set; }
		public DateTime DateCreation { get; set; }
		public DateTime? DateDesactivation { get; set; }
		//public string Role { get; set; }
	}
}