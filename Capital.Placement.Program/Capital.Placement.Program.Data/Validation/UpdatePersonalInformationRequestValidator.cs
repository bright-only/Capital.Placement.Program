using Capital.Placement.Program.Data.DTOs;
using Capital.Placement.Program.Data.Helper;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capital.Placement.Program.Data.Validation
{
    public class UpdatePersonalInformationRequestValidator : GenericPersonalInformationlValidator<UpdatePersonalInformationRequestDTO>
    {
        public UpdatePersonalInformationRequestValidator()
        {
           
        }
    }
}
