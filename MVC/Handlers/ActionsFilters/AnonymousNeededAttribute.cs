using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using MVC.Handlers;

namespace MVC.Handlers.ActionFilters
{
	[AttributeUsage(AttributeTargets.Method)]
	public class AnonymousNeededAttribute : Attribute, IActionFilter
	{
		public void OnActionExecuted(ActionExecutedContext context)
		{
			return;
		}

		public void OnActionExecuting(ActionExecutingContext context)
		{
			if (context.HttpContext.Session.GetString(nameof(SessionManager.ConnectedUser)) is not null)
			{
				context.Result = new RedirectToActionResult("Index", "Home", null);
			}
		}
	}
}