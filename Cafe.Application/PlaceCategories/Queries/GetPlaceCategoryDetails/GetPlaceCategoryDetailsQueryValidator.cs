using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe.Application.PlaceCategories.Queries.GetPlaceCategoryDetails {
	public class GetPlaceCategoryDetailsQueryValidator : AbstractValidator<GetPlaceCategoryDetailsQuery>{
        public GetPlaceCategoryDetailsQueryValidator()
        {
            RuleFor(pc=>pc.Id).NotEqual(Guid.Empty);
            RuleFor(pc=>pc.UserId).NotEqual(Guid.Empty);
        }
    }
}
