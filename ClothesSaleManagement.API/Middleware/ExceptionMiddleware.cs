using System.Net;
using ClothesSaleManagement.Application.Exceptions;
using Newtonsoft.Json;

namespace ClothesSaleManagement.API.Middleware
{
	public class ExceptionMiddleware
	{
		private readonly RequestDelegate _next;

		public ExceptionMiddleware(RequestDelegate next)
		{
			_next = next;
		}

		public async Task Invoke(HttpContext context)
		{
			try
			{
				await _next.Invoke(context);
			}
			catch (Exception e)
			{
				await HandleException(context, e);
			}
		}

		private Task HandleException(HttpContext context, Exception exception)
		{
			context.Response.ContentType = "application/json";
			HttpStatusCode statusCode = HttpStatusCode.InternalServerError;
			string result = JsonConvert.SerializeObject(new ErrorDetail()
			{
				ErrorType = "Failure",
				ErrorMessage = exception.Message
			});

			switch (exception)
			{
				case NotFoundException notFound:
					statusCode = HttpStatusCode.NotFound;
					break;
				case BadRequestException badRequestException:
					statusCode = HttpStatusCode.BadRequest;
					break;
				default:
					break;
			}

			context.Response.StatusCode = (int)statusCode;
			return context.Response.WriteAsync(result);
		}

		public class ErrorDetail
		{
			public string ErrorType { get; set; }
			public string ErrorMessage { get; set; }
		}
	}
}
