using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Linq;

namespace TechSolution.API.Extensions
{
    public class SwaggerOptionsConfig : IConfigureOptions<SwaggerGenOptions>
    {
        private readonly IApiVersionDescriptionProvider _provider;

        public SwaggerOptionsConfig(IApiVersionDescriptionProvider provider)
        {
            _provider = provider;
        }

        public void Configure(SwaggerGenOptions options)
        {
            foreach (var description in _provider.ApiVersionDescriptions)
            {
                options.SwaggerDoc(description.GroupName, CreateInfoForApiVersion(description));
            }
        }

        public static OpenApiInfo CreateInfoForApiVersion(ApiVersionDescription description)
        {
            var info = new OpenApiInfo
            {
                Title = "Web API",
                Description = "A simple web api",
                TermsOfService = new Uri("https://docs.microsoft.com/pt-br/aspnet/core/tutorials/first-web-api?view=aspnetcore-3.1"),
                Contact = new OpenApiContact { Name = "Eduardo C. Costa", Email = "eduardocosta1997@outlook.com" },
                License = new OpenApiLicense { Name = "MIT", Url = new Uri("https://opensource.org/licenses/MIT") }
            };

            if (description.IsDeprecated) info.Description = "Obsolete version";

            return info;
        }

    }

    public class SwaggerDefaultValues : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            if (operation.Parameters == null) return;

            foreach (var parameter in operation.Parameters)
            {
                var description = context.ApiDescription.ParameterDescriptions.First(x => x.Name == parameter.Name);

                var routeInfo = description.RouteInfo;

                operation.Deprecated = OpenApiOperation.DeprecatedDefault;

                if (parameter.Description == null)
                    parameter.Description = description.ModelMetadata?.Description;

                if (routeInfo == null) continue;

                if (parameter.In != ParameterLocation.Path && parameter.Schema.Default == null)
                    parameter.Schema.Default = new OpenApiString(routeInfo.DefaultValue.ToString());

                parameter.Required |= !routeInfo.IsOptional;
            }
        }
    }
}
