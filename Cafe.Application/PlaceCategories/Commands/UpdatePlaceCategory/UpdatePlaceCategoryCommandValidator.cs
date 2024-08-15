using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe.Application.PlaceCategories.Commands.UpdatePlaceCategory {
	public class UpdatePlaceCategoryCommandValidator : AbstractValidator<UpdatePlaceCategoryCommand>{
        public UpdatePlaceCategoryCommandValidator()
        {
            RuleFor(pc=>pc.Name).NotEmpty().MaximumLength(250);
            RuleFor(pc=>pc.Id).NotEqual(Guid.Empty);
            RuleFor(pc=>pc.UserId).NotEqual(Guid.Empty);
		}

    }
}
