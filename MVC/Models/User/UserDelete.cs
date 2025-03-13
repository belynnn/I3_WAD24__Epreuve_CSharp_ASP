using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace MVC.Models.User
{
	public class UserDelete
	{
		[ScaffoldColumn(false)]
		public int UtilisateurId { get; set; }

		[DisplayName("Pseudo")]
		public required string Pseudo { get; set; }

		[DisplayName("E-mail")]
		[EmailAddress]
		public required string Email { get; set; }

		[DisplayName("Date de désactivation")]
		public DateOnly DateDesactivation { get; set; }
	}
}