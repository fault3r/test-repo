using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.DependencyInjection;

namespace BookApi_Infrastructure.Configurations
{
    public static class ApiVersioningConfiguration
    {
        public static IServiceCollection AddApiVersioningConfiguration(this IServiceCollection services, int version)
        {
            return services.AddApiVersioning(options =>
            {
                options.DefaultApiVersion = new ApiVersion(version, 0);
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.ReportApiVersions = true;
                options.ApiVersionReader = ApiVersionReader.Combine(
                    new HeaderApiVersionReader("api-version"),
                    new QueryStringApiVersionReader("v"),
                    new UrlSegmentApiVersionReader());
            });
        }
    }

}