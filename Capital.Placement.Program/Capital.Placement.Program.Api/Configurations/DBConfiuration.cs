using Capital.Placement.Program.Data.Context;

using Microsoft.EntityFrameworkCore;

namespace Capital.Placement.Program.Api.Configurations
{
    public static class DBConfiuration
    {
        public static void Configure( IServiceCollection services, IConfiguration config )
        {
            var url = config["CosmosDbSetting:URI"] ?? "";
            var accountKey = config["CosmosDbSetting:Primary Key"] ?? "";
            var databaseName = config["CosmosDbSetting:DbName"] ?? "";
            services.AddDbContext<ApplicationDBContext>(options =>
            {
                options.UseCosmos(url, accountKey, databaseName);
            });
        }
    }
}
