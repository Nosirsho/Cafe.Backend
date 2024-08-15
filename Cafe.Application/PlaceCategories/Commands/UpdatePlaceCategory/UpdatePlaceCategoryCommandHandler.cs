using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Cafe.Application.Common.Exceptions;
using Cafe.Application.Interfaces;
using Cafe.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Cafe.Application.PlaceCategories.Commands.UpdatePlaceCategory {
	public class UpdatePlaceCategoryCommandHandler : IRequestHandler<UpdatePlaceCategoryCommand> {
		private readonly ICafeDbContext _dbContext;
        public UpdatePlaceCategoryCommandHandler(ICafeDbContext dbContext) => _dbContext = dbContext;
        
        public async Task<Unit> Handle(UpdatePlaceCategoryCommand request, CancellationToken cancellationToken) {
			var entity = await _dbContext.PlaceCategories.FirstOrDefaultAsync(pc => pc.Id == request.Id, cancellationToken);
			if (entity == null || entity.UserId != request.UserId) {
				throw new NotFoundException(nameof(PlaceCategory), request.Id);
			}
			entity.Name = request.Name;
			entity.EditDate = DateTime.Now;

			await _dbContext.SaveChangesAsync(cancellationToken);

			return Unit.Value;
		}
	}
}
