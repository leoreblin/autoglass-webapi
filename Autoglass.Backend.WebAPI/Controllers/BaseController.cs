using FluentResults;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Net;

namespace Autoglass.Backend.WebAPI.Controllers
{
    public class BaseController : ControllerBase
    {
        protected IActionResult FluentResult(ResultBase result, HttpStatusCode? statusCode = null)
        {
            var errors = result.Errors
                .Select(e => new
                {
                    message = e.Message,
                    details = e.Reasons?.Select(r => r.Message),
                    code = statusCode
                });

            return new ObjectResult(new { error = new { errors } });
        }
    }
}
