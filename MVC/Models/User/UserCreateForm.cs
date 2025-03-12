using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace MVC.Models.User
{
	public class UserCreateForm
	{
		[DisplayName("Pseudo : ")]
		[Required(ErrorMessage = "Le champ 'Pseudo' est obligatoire.")]
		[MinLength(2, ErrorMessage = "Le champ 'Pseudo' doit contenir au minimum 2 caractères.")]
		[MaxLength(64, ErrorMessage = "Le champ 'Pseudo' doit contenir au maximum 50 caractères.")]
		public string Pseudo { get; set; }

		[DisplayName("E-mail : ")]
		[Required(ErrorMessage = "Le champ 'E-mail' est obligatoire.")]
		[EmailAddress]
		public string Email { get; set; }

		[DisplayName("Mot de passe : ")] 
		[Required(ErrorMessage = "Le champ 'Mot de passe' est obligatoire.")]
		[MinLength(8, ErrorMessage = "Le champ 'Mot de passe' doit contenir au minimum 8 caractères.")]
		[MaxLength(32, ErrorMessage = "Le champ 'Mot de passe' doit contenir au maximum 32 caractères.")]
		[RegularExpression(@"^.*(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[\-_+=\.()\[\]$µ£\\/*§?{}]).*", ErrorMessage = "Le champ 'Mot de passe' doit contenir au minimum une minuscule, une majuscule, un chiffre et un symbole.")]
		[DataType(DataType.Password)]
		public string MotDePasse { get; set; }

		[DisplayName("Veuillez confirmer le mot de passe : ")]
		[Required(ErrorMessage = "La confirmation du 'Mot de passe' est obligatoire.")]
		[Compare(nameof(MotDePasse), ErrorMessage = "La confirmation ne correspond pas au champ 'Mot de passe'.")]
		[DataType(DataType.Password)]
		public string ConfirmerMotDePasse { get; set; }

		[DisplayName("En cochant cette case, vous acceptez les termes du contrats des conditions générales d'utilisation de notre plateforme.")]
		[Required(ErrorMessage = "Vous devez lire et accepter les termes des conditions d'utilisation.")]
		public bool Consentement { get; set; }
	}
}