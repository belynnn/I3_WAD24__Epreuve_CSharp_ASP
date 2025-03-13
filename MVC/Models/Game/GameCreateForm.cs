using System;
using System.ComponentModel.DataAnnotations;

namespace MVC.Models.Game
{
	public class GameCreateForm
	{
		[Required]
		[StringLength(100, ErrorMessage = "Le nom du jeu ne peut pas dépasser 100 caractères.")]
		public string Nom { get; set; }

		[Required]
		[StringLength(int.MaxValue, ErrorMessage = "La description ne peut pas être vide.")]
		public string Description { get; set; }

		[Range(0, 100, ErrorMessage = "L'âge minimum doit être entre 0 et 100.")]
		public int AgeMin { get; set; }

		[Range(0, 100, ErrorMessage = "L'âge maximum doit être entre 0 et 100.")]
		public int AgeMax { get; set; }

		[Range(1, int.MaxValue, ErrorMessage = "Le nombre minimum de joueurs doit être au moins 1.")]
		public int NbJoueurMin { get; set; }

		[Range(1, int.MaxValue, ErrorMessage = "Le nombre maximum de joueurs doit être au moins 1.")]
		public int NbJoueurMax { get; set; }

		[Range(1, 120, ErrorMessage = "La durée du jeu doit être entre 1 et 120 minutes.")]
		public int? DureeMinute { get; set; }

		[DataType(DataType.Date)]
		public DateTime DateCreation { get; set; } = DateTime.Now;
	}
}