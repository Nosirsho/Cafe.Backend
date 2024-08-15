using FluentValidation;
using FluentValidation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe.Application.PlaceCategories.Commands.DeletePlaceCategory {
	public class DeletePlaceCategoryCommandValidator : AbstractValidator<DeletePlaceCategoryCommand>{
        public DeletePlaceCategoryCommandValidator()
        {
            RuleFor(pc => pc.Id).NotEqual(Guid.Empty);
            RuleFor(pc => pc.UserId).NotEqual(Guid.Empty);
        }
    }
}
