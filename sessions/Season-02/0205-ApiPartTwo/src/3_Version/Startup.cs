using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace _3_Version
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{

			services.AddControllers();

			services.AddApiVersioning(v =>
			{
				v.DefaultApiVersion = new ApiVersion(1, 0);
				v.AssumeDefaultVersionWhenUnspecified = true;
				v.ReportApiVersions = true;
			});

			services.AddVersionedApiExplorer(options => options.GroupNameFormat = "'v'VVV");

			services.AddSwaggerGen(c =>
						{
							c.SwaggerDoc("v1", new OpenApiInfo { Title = "Fritz's Contacts v1", Version = "v1" });
							c.SwaggerDoc("v2", new OpenApiInfo { Title = "Fritz's NEW Contacts v2", Version = "v2" });

							c.OperationFilter<RemoveVersionFromParameter>();
							c.DocumentFilter<ReplaceVersionWithExactValueInPath>();

						});
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				app.UseSwagger();
				app.UseSwaggerUI(c => {
					c.SwaggerEndpoint("/swagger/v1/swagger.json", "Fritz's Contacts v1");
					c.SwaggerEndpoint("/swagger/v2/swagger.json", "Fritz's NEW Contacts v2");
				});
			}

			app.UseHttpsRedirection();

			app.UseRouting();

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}
