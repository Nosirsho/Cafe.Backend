using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Cafe.Domain;
using Cafe.Application.Interfaces;

namespace Cafe.Application.PlaceCategories.Commands.CreatePlaceCategory {
	public class CreatePlaceCategoryCommandHandler : IRequestHandler<CreatePlaceCategoryCommand, Guid> {
        public CreatePlaceCategoryCommandHandler(ICafeDbContext dbContext) => _dbContext = dbContext;
        
        private readonly ICafeDbContext _dbContext;
		public async Task<Guid> Handle(CreatePlaceCategoryCommand request, CancellationToken cancellationToken) {
			var placeCategory = new PlaceCategory { 
				UserId = request.UserId,
				Name = request.Name,
				Id = Guid.NewGuid(),
				CreationDate = DateTime.Now,
				EditDate = null
			};
			
			await _dbContext.PlaceCategories.AddAsync(placeCategory, cancellationToken);
			await _dbContext.SaveChangesAsync(cancellationToken);

			return placeCategory.Id;
		}
	}
}
