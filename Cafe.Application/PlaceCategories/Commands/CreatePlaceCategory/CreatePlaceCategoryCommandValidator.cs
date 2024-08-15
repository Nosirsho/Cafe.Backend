using System;
using FluentValidation;

namespace Cafe.Application.PlaceCategories.Commands.CreatePlaceCategory {
	public class CreatePlaceCategoryCommandValidator : AbstractValidator<CreatePlaceCategoryCommand>{
        public CreatePlaceCategoryCommandValidator()
        {
            RuleFor(createPCCommand => createPCCommand.Name).NotEmpty().MaximumLength(250);
            RuleFor(createPCCommand => createPCCommand.UserId).NotEqual(Guid.Empty);
		}
    }
}
