using Cafe.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Cafe.Application.Interfaces {
	public interface ICafeDbContext {
		DbSet<PlaceCategory> PlaceCategories { get; set; }
		Task<int> SaveChangesAsync(CancellationToken cancellationToken);
	}
}
