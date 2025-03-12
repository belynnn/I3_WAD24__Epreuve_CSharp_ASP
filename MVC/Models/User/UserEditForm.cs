using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace MVC.Models.User
{
	public class UserEditForm
	{
		[DisplayName("Pseudo : ")]
		[Required(ErrorMessage = "Le champ 'Pseudo' est obligatoire.")]
		[MinLength(2, ErrorMessage = "Le champ 'Pseudo' doit contenir au minimum 2 caractères.")]
		[MaxLength(64, ErrorMessage = "Le champ 'Pseudo' doit contenir au maximum 50 caractères.")]
		public string Pseudo { get; set; }
	}
}