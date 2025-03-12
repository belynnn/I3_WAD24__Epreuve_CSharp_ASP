using DAL.Services;

namespace TestConsoleDAL
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Hello, World!");

			UserService service = new UserService();

			foreach (DAL.Entities.User u in service.Get())
			{
				Console.WriteLine($"{u.Pseudo} : {u.Email} {u.MotDePasse}");
			}
		}
	}
}