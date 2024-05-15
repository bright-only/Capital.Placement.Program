using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capital.Placement.Program.Service.BusinessLogic
{
    public class AuthService : IAuthService
    {
        private readonly IConfiguration _config;
        public AuthService( IConfiguration config )
        {
            _config = config;
        }

        public bool ValidateCredentials( string username, string password )
        {
            var storedUsername = _config["AuthUser:Username"] ?? "";
            var storedPassword = _config["AuthUser:Password"] ?? "";
            return username.ToLower().Equals(storedUsername.ToLower()) && password.ToLower().Equals(storedPassword.ToLower());
        }
    }
}
