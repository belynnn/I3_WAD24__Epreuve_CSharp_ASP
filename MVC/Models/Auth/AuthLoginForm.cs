using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace MVC.Models.Auth
{
	public class AuthLoginForm
	{
		[DisplayName("E-mail : ")]
		[Required(ErrorMessage = "Le champ 'E-mail' est obligatoire.")]
		[EmailAddress]
		public string Email { get; set; }

		[DisplayName("Mot de passe : ")]
		[Required(ErrorMessage = "Le champ 'Mot de passe' est obligatoire.")]
		[MinLength(8, ErrorMessage = "Le champ 'Mot de passe' doit contenir au minimum 16 caractères.")]
		[MaxLength(32, ErrorMessage = "Le champ 'Mot de passe' doit contenir au maximum 32 caractères.")]
		[RegularExpression(@"^.*(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[\-_+=\.()\[\]$µ£\\/*§?{}]).*", ErrorMessage = "Le champ 'Mot de passe' doit contenir au minimum une minuscule, une majuscule, un chiffre et un symbole.")]
		[DataType(DataType.Password)]
		public string MotDePasse { get; set; }
	}
}