using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Services
{
	// Base service
	public abstract class BaseService
	{
		// Connection string
		protected readonly string _connectionString;

		// Constructor
		public BaseService(IConfiguration config, string dbname)
		{
			_connectionString = config.GetConnectionString(dbname) ?? throw new Exception("Pas de ConnectionString correspondante.");
		}
	}
}