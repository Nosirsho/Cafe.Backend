using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe.Application.PlaceCategories.Queries.GetPlaceCategoryDetails {
	public class GetPlaceCategoryDetailsQuery : IRequest<PlaceCategryDetailsVm>{
		public Guid UserId { get; set; }
		public Guid Id { get; set; }

	}
}
