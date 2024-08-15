using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Cafe.Application.Common.Exceptions;
using Cafe.Application.Interfaces;
using Cafe.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Cafe.Application.PlaceCategories.Queries.GetPlaceCategoryDetails {
	public class GetPlaceCategoryDetailsQueryHandler : IRequestHandler<GetPlaceCategoryDetailsQuery, PlaceCategryDetailsVm> {
		private readonly ICafeDbContext _dbContext;
		private readonly IMapper _mapper;
		public GetPlaceCategoryDetailsQueryHandler(ICafeDbContext dbContext, IMapper mapper) 
			=> (_dbContext, _mapper) = (dbContext, mapper);
        public async Task<PlaceCategryDetailsVm> Handle(GetPlaceCategoryDetailsQuery request, CancellationToken cancellationToken) {
			var entity = await _dbContext.PlaceCategories.FirstOrDefaultAsync(pc => pc.Id == request.Id, cancellationToken);
			if (entity == null || entity.UserId != request.UserId) {
				throw new NotFoundException(nameof(PlaceCategory), request.Id);
			}

			return _mapper.Map<PlaceCategryDetailsVm>(entity);
		}
	}
}
