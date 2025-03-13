using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MVC.Models.Game
{
	public class GameEditForm
	{
		[ScaffoldColumn(false)]
		public int JeuId { get; set; }

		[DisplayName("Nom du jeu : ")]
		[Required(ErrorMessage = "Le nom du jeu est requis.")]
		[StringLength(100, ErrorMessage = "Le nom du jeu ne peut pas dépasser 100 caractères.")]
		public string Nom { get; set; }

		[DisplayName("Description : ")]
		[Required(ErrorMessage = "La description est requise.")]
		public string Description { get; set; }

		[DisplayName("Âge minimum : ")]
		[Range(0, 100, ErrorMessage = "L'âge minimum doit être compris entre 0 et 100.")]
		public int AgeMin { get; set; }

		[DisplayName("Âge maximum : ")]
		[Range(0, 100, ErrorMessage = "L'âge maximum doit être compris entre 0 et 100.")]
		public int AgeMax { get; set; }

		[DisplayName("Nombre de joueurs minimum : ")]
		[Range(1, 100, ErrorMessage = "Le nombre minimum de joueurs doit être entre 1 et 100.")]
		public int NbJoueurMin { get; set; }

		[DisplayName("Nombre de joueurs maximum : ")]
		[Range(1, 100, ErrorMessage = "Le nombre maximum de joueurs doit être entre 1 et 100.")]
		public int NbJoueurMax { get; set; }

		[DisplayName("Durée du jeu (en minutes) : ")]
		[Range(1, 600, ErrorMessage = "La durée du jeu doit être comprise entre 1 et 600 minutes.")]
		public int? DureeMinute { get; set; }

		[DisplayName("Date de création : ")]
		[DataType(DataType.Date)]
		public DateTime DateCreation { get; set; }

		[DisplayName("Jeu désactivé : ")]
		public bool IsDisabled { get; set; }
	}
}