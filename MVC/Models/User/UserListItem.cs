using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace MVC.Models.User
{
	public class UserListItem
	{
		[ScaffoldColumn(false)]
		public int UtilisateurId { get; set; }

		[DisplayName("Pseudo")]
		public string Pseudo { get; set; }
	}
}