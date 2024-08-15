using Cafe.Application.Common.Exceptions;
using Cafe.Application.Interfaces;
using Cafe.Domain;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Cafe.Application.PlaceCategories.Commands.DeletePlaceCategory {

	public class DeletePlaceCategoryCommandHandler : IRequestHandler<DeletePlaceCategoryCommand>{
		private readonly ICafeDbContext _dbContext;
        public DeletePlaceCategoryCommandHandler(ICafeDbContext dbContext) => _dbContext = dbContext;
        
        public async Task<Unit> Handle(DeletePlaceCategoryCommand request, CancellationToken cancellationToken) { 

			var entity = await _dbContext.PlaceCategories.FindAsync(new object[] { request.Id}, cancellationToken);

			if (entity == null || entity.UserId != request.UserId) {
				throw new NotFoundException(nameof(PlaceCategory), request.Id);
			}
			_dbContext.PlaceCategories.Remove(entity);
			await _dbContext.SaveChangesAsync(cancellationToken);
			return Unit.Value;
		}
		
	}
}
