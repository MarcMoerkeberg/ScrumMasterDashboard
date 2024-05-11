using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ScrumMasterDashboard.Api.Exceptions
{
	public class GlobalExceptionHandler : IExceptionHandler
	{
		public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
		{
			bool handledException = false;
			//Log error message with exception.
			//Create problemdetails
			var problemDetails = new ProblemDetails
			{
				Status = (int)HttpStatusCode.InternalServerError,
				Type = exception.GetType().Name,
				Title = "",
				Detail = exception.Message
			};

			await httpContext.Response.WriteAsJsonAsync(problemDetails, cancellationToken);
			handledException = true;

			return handledException;
		}
	}
}
