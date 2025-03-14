using BLL.Entities;
using BLL.Mappers;
using D = DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Repositories;

namespace BLL.Services
{
	// UserService implémente IUserRepository<User>
	public class UserService : IUserRepository<User>
	{
		// _userService est une instance de IUserRepository<D.User>
		private IUserRepository<D.User> _userService;

		// Constructeur
		public UserService(IUserRepository<D.User> userService)
		{
			_userService = userService;
		}

		public IEnumerable<User> Get()
		{
			return _userService.Get().Select(dal => dal.ToBLL());
		}

		public IEnumerable<User> GetAll()
		{
			return _userService.GetAll().Select(dal => dal.ToBLL());
		}

		public IEnumerable<User> GetAllActive()
		{
			return _userService.GetAllActive().Select(dal => dal.ToBLL());
		}

		public User Get(int user_id)
		{
			User user = _userService.Get(user_id).ToBLL();
			return user;
		}

		public int Insert(User user)
		{
			return _userService.Insert(user.ToDAL());
		}

		public void Update(int user_id, User user)
		{
			_userService.Update(user_id, user.ToDAL());
		}

		public void Delete(int user_id)
		{
			_userService.Delete(user_id);
		}

		public int CheckPassword(string email, string password)
		{
			return _userService.CheckPassword(email, password);
		}
	}
}