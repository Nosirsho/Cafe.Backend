using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;
using Cafe.Application.Interfaces;

namespace Cafe.Persistence {
	public static class DependencyInjection {
		public static IServiceCollection AddPersistence(this IServiceCollection service, IConfiguration configuration) {
			var connectionString = configuration["DbConnection"];
			service.AddDbContext<CafeDbContext>(opt => opt.UseSqlite(connectionString));
			service.AddScoped<ICafeDbContext>(provider => provider.GetService<CafeDbContext>());
			return service;
		}
	}
}
