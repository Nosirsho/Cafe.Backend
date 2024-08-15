using Cafe.Domain;
using Cafe.Application.Interfaces;
using Cafe.Persistence.EntityTypeConfigurations;

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe.Persistence {
	public class CafeDbContext : DbContext, ICafeDbContext{
		public DbSet<PlaceCategory> PlaceCategories { get; set; }
		public CafeDbContext(DbContextOptions<CafeDbContext> options) 
			: base(options){ }

		protected override void OnModelCreating(ModelBuilder builder) {
			builder.ApplyConfiguration( new PlaceCategoryConfiguration());
			base.OnModelCreating(builder);
		}
	}
}
