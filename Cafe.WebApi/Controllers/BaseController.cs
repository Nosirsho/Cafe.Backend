using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Security.Claims;

namespace Cafe.WebApi.Controllers {
	[ApiController]
	[Route("api/[controller]/[action]")]
	public abstract class BaseController : ControllerBase {
		private IMediator _mediator;
		protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

		internal Guid UserId => !User.Identity.IsAuthenticated 
			//? Guid.Empty 
			? new Guid("516EF0D1-9EA1-4B88-8649-84D60BAC64DF")
			: Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
		


	}
}
