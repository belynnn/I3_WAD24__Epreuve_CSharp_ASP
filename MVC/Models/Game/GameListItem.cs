using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace MVC.Models.Game
{
	public class GameListItem
	{
		[ScaffoldColumn(false)]
		public int JeuId { get; set; }

		[DisplayName("Nom du jeu")]
		public string Nom { get; set; }

		[DisplayName("Description")]
		public string Description { get; set; }

		[DisplayName("Âge minimum")]
		public int AgeMin { get; set; }

		[DisplayName("Âge maximum")]
		public int AgeMax { get; set; }

		[DisplayName("Nombre minimum de joueurs")]
		public int NbJoueurMin { get; set; }

		[DisplayName("Nombre maximum de joueurs")]
		public int NbJoueurMax { get; set; }

		[DisplayName("Durée (en minutes)")]
		public int? DureeMinute { get; set; }

		[DisplayName("Date de création")]
		public DateTime DateCreation { get; set; }

		[DisplayName("Désactivé")]
		public bool IsDisabled { get; set; }
	}
}