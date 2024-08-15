using System;
using FluentValidation;

namespace Cafe.Application.PlaceCategories.Queries.GetPlaceCategoryList {
	public class GetPlaceCategoryListQueryValidator : AbstractValidator<GetPlaceCategoryListQuery> {
        public GetPlaceCategoryListQueryValidator()
        {
            RuleFor(pc => pc.UserId).NotEqual(Guid.Empty);
        }
    }
}
