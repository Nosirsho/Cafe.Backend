using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe.Application.PlaceCategories.Commands.UpdatePlaceCategory {
	public class UpdatePlaceCategoryCommand : IRequest {
		public Guid Id { get; set; }
		public Guid UserId { get; set; }
		public string Name { get; set; }

	}
}
