using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Cafe.Application.PlaceCategories.Commands.CreatePlaceCategory
{
    public class CreatePlaceCategoryCommand : IRequest<Guid>
    {
        public Guid UserId { get; set; }
        public string Name { get; set; }
    }
}
