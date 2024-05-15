using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capital.Placement.Program.Service.BusinessLogic
{
    public interface IAuthService
    {
        bool ValidateCredentials( string clientId, string clientSecret );
    }
}
