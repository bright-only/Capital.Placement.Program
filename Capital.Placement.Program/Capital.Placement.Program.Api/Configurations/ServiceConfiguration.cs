using Capital.Placement.Program.Data.DTOs;
using Capital.Placement.Program.Data.Model;
using Capital.Placement.Program.Data.Repositories;
using Capital.Placement.Program.Data.Validation;
using Capital.Placement.Program.Service.BusinessLogic;

using FluentValidation;
using Microsoft.AspNetCore.Authentication;

namespace Capital.Placement.Program.Api.Configurations
{
    public static class ServiceConfiguration
    {
        public static void ConfigureServices( IServiceCollection services )
        {
            // PersonalInformation services
            services.AddScoped<IPersonalInformationService, PersonalInformationService>();
            // Register AuthService
            services.AddScoped<IAuthService, AuthService>();
            // Register BasicAuthenticationHandler
            services.AddAuthentication("BasicAuthentication")
                .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", null);


            // Register repositories
            services.AddScoped<IGenericRepository<PersonalInformation>, GenericRepository<PersonalInformation>>();

            //Validator
            services.AddTransient<IValidator<AddPersonalInformationRequestDTO>, AddPersonalInformationRequestValidator>();
            services.AddTransient<IValidator<UpdatePersonalInformationRequestDTO>, UpdatePersonalInformationRequestValidator>();
        }
    }
}
