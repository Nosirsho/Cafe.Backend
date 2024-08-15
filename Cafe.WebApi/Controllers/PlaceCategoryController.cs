using AutoMapper;
using Cafe.Application.PlaceCategories.Commands.CreatePlaceCategory;
using Cafe.Application.PlaceCategories.Commands.DeletePlaceCategory;
using Cafe.Application.PlaceCategories.Commands.UpdatePlaceCategory;
using Cafe.Application.PlaceCategories.Queries.GetPlaceCategoryDetails;
using Cafe.Application.PlaceCategories.Queries.GetPlaceCategoryList;
using Cafe.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Cafe.WebApi.Controllers {
	[Route("api/[controller]")]
	public class PlaceCategoryController : BaseController {
		private readonly IMapper _mapper;
		public PlaceCategoryController(IMapper mapper) => _mapper = mapper;

		[HttpGet]
		public async Task<ActionResult<PlaceCategoryListVm>> GetAll() {
			var query = new GetPlaceCategoryListQuery { 
				UserId = UserId
			};

			var vm = await Mediator.Send(query);
			return Ok(vm);
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<PlaceCategryDetailsVm>> Get(Guid id) {
			var query = new GetPlaceCategoryDetailsQuery { 
				UserId = UserId,
				Id = id
			};
			var vm = await Mediator.Send(query);
			return Ok(vm);
		}

		[HttpPost]
		public async Task<ActionResult<Guid>> Create([FromBody] CreatePlaceCategoryDto createPlaceCategory) {
			var command = _mapper.Map<CreatePlaceCategoryCommand>(createPlaceCategory);
			command.UserId = UserId;
			var pcId = await Mediator.Send(command);
			return Ok(pcId);
		}

		[HttpPut]
		public async Task<IActionResult> Update([FromBody] UpdatePlaceCategoryDto updatePlaceCategory) {
			var command = _mapper.Map<UpdatePlaceCategoryCommand>(updatePlaceCategory);
			command.UserId = UserId;
			await Mediator.Send(command);
			return NoContent();
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(Guid id) {
			var command = new DeletePlaceCategoryCommand { 
				Id = id,
				UserId = UserId
			};

			await Mediator.Send(command);
			return NoContent();
		}
	}
}