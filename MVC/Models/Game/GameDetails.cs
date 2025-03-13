using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MVC.Models.Game
{
	public class GameDetails
	{
		[ScaffoldColumn(false)]
		public int JeuId { get; set; }

		[DisplayName("Nom du jeu : ")]
		public string Nom { get; set; }

		[DisplayName("Description : ")]
		public string Description { get; set; }

		[DisplayName("Âge minimum : ")]
		public int AgeMin { get; set; }

		[DisplayName("Âge maximum : ")]
		public int AgeMax { get; set; }

		[DisplayName("Nombre de joueurs minimum : ")]
		public int NbJoueurMin { get; set; }

		[DisplayName("Nombre de joueurs maximum : ")]
		public int NbJoueurMax { get; set; }

		[DisplayName("Durée du jeu (en minutes) : ")]
		public int? DureeMinute { get; set; }

		[DisplayName("Date de création : ")]
		[DataType(DataType.Date)]
		public DateTime DateCreation { get; set; }

		[DisplayName("Jeu désactivé : ")]
		public bool IsDisabled { get; set; }
	}
}