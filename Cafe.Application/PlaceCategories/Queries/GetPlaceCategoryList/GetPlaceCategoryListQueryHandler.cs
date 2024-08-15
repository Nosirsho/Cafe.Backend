using AutoMapper;
using AutoMapper.QueryableExtensions;
using Cafe.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Cafe.Application.PlaceCategories.Queries.GetPlaceCategoryList {
	public class GetPlaceCategoryListQueryHandler : IRequestHandler<GetPlaceCategoryListQuery, PlaceCategoryListVm> {
		private readonly ICafeDbContext _dbContext;
		private readonly IMapper _mapper;
		public GetPlaceCategoryListQueryHandler(ICafeDbContext dbContext, IMapper mapper) => (_dbContext, _mapper) = (dbContext, mapper);

		public async Task<PlaceCategoryListVm> Handle(GetPlaceCategoryListQuery request, CancellationToken cancellationToken) { 
			var pcQuery = await _dbContext.PlaceCategories.Where(pc=>pc.UserId == request.UserId)
				.ProjectTo<PlaceCategoryLookupDto>(_mapper.ConfigurationProvider)
				.ToListAsync(cancellationToken);
			return new PlaceCategoryListVm { PlaceCategories = pcQuery };
		}
    }
}
