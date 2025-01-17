using Cafe.Application;
using Cafe.Application.Common.Mappings;
using Cafe.Application.Interfaces;
using Cafe.Persistence;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Cafe.WebApi {
	public class Startup {
		// This method gets called by the runtime. Use this method to add services to the container.
		// For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940

		public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)=> Configuration = configuration;
        

        public void ConfigureServices(IServiceCollection services) {
			services.AddAutoMapper(config => {
				config.AddProfile(new AssemblyMappingProfile(Assembly.GetExecutingAssembly()));
				config.AddProfile(new AssemblyMappingProfile(typeof(ICafeDbContext).Assembly));
			});

			services.AddApplication();
			services.AddPersistence(Configuration);
			services.AddControllers();

			services.AddCors(options=> {
				options.AddPolicy("AllowAll", policy => {
					policy.AllowAnyHeader();
					policy.AllowAnyMethod();
					policy.AllowAnyOrigin();
				});
			});

		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
			if (env.IsDevelopment()) {
				app.UseDeveloperExceptionPage();
			}

			app.UseRouting();
			app.UseHttpsRedirection();
			app.UseCors("AllowAll");

			app.UseEndpoints(endpoints => {
				endpoints.MapControllers();
			});
		}
	}
}
