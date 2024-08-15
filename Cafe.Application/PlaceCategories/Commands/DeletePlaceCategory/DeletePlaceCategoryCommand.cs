using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Cafe.Application.PlaceCategories.Commands.DeletePlaceCategory {
	public class DeletePlaceCategoryCommand : IRequest{
		public Guid Id { get; set; }
		public Guid UserId { get; set; }
	}
}
