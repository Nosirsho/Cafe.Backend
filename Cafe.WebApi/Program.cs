using Cafe.Persistence;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cafe.WebApi {
	public class Program {
		public static void Main(string[] args) {
			var host = CreateHostBuilder(args).Build();

			using (var scope = host.Services.CreateScope()) { 
				var serviceProvider =scope.ServiceProvider;
				try {
					var context = serviceProvider.GetRequiredService<CafeDbContext>();
					DbInitializer.Initialize(context);
				} catch (Exception ex) { 

				}
			}

			host.Run();
		}

		public static IHostBuilder CreateHostBuilder(string[] args) =>
			Host.CreateDefaultBuilder(args)
				.ConfigureWebHostDefaults(webBuilder => {
					webBuilder.UseStartup<Startup>();
				});
	}
}
