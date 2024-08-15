using Cafe.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe.Persistence.EntityTypeConfigurations {
	public class PlaceCategoryConfiguration : IEntityTypeConfiguration<PlaceCategory> {

		public void Configure(EntityTypeBuilder<PlaceCategory> builder) {
			builder.HasKey(x => x.Id);
			builder.HasIndex(x => x.Id).IsUnique();
			builder.Property(x => x.Name).HasMaxLength(256);
		}
	}
}
