﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Repositories
{
	public interface IGameRepository<TGame> : ICRUDRepository<TGame, int>
	{
		IEnumerable<TGame> GetTop10MostRentedGames();
		IEnumerable<TGame> Search(string searchQuery);  // Recherche par nom
	}
}