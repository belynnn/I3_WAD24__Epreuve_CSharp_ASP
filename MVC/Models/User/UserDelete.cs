using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace MVC.Models.User
{
	public class UserDelete
	{
		[DisplayName("Pseudo")]
		public string Pseudo { get; set; }

		[DisplayName("E-mail")]
		[EmailAddress]
		public string Email { get; set; }

		[DisplayName("Date de désactivation")]
		public DateOnly DateDesactivation { get; set; }
	}
}