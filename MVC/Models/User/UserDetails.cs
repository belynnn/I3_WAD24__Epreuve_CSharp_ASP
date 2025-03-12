using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace MVC.Models.User
{
	public class UserDetails
	{
		[ScaffoldColumn(false)]
		public int UtilisateurId { get; set; }

		[DisplayName("Pseudo : ")]
		public string Pseudo { get; set; }

		[DisplayName("E-mail : ")]
		[EmailAddress]
		public string Email { get; set; }

		[DisplayName("Date d'inscription : ")]
		[DataType(DataType.Date)]
		public DateOnly DateCreation { get; set; }
	}
}