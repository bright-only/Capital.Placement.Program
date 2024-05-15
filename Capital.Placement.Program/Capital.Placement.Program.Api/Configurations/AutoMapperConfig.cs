using Capital.Placement.Program.Data.DTOs;

using System.Reflection;

namespace Capital.Placement.Program.Api.Configurations
{
    public static class AutoMapperConfig
    {
        public static void Configure( IServiceCollection services, params Assembly[] additionalAssemblies )
        {
            services.AddAutoMapper(typeof(AddPersonalInformationRequestMapper));
        }
    }
}
