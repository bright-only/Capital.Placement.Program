using Microsoft.OpenApi.Models;

namespace Capital.Placement.Program.Api.Configurations
{
    public static class SwaggerConfiguration
    {
        public static void Services( IServiceCollection services, IConfiguration config )
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "CAPITAL REPLACEMENT PROGRAM API",
                    Version = "v1",
                    Contact = new OpenApiContact
                    {
                        Name = "CAPITAL REPLACEMENT"
                    },
                    Description = "<h2>Description</h2><p>This is the api for CAPITAL REPLACEMENT.</p>"
                });
                options.AddSecurityDefinition("basic", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    Scheme = "basic",
                    In = ParameterLocation.Header,
                    Description = "Basic Authorization header using the Bearer scheme."
                });
                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                     {
                           new OpenApiSecurityScheme
                           {
                                 Reference = new OpenApiReference
                                 {
                                     Type = ReferenceType.SecurityScheme,
                                     Id = "basic"
                                 }
                             },
                             new string[] {}
                     }
                });
                options.ResolveConflictingActions(b => b.First());

            });

        }
    }
}
