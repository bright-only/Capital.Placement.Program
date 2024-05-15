using Capital.Placement.Program.Data.Helper;

using FluentValidation;

namespace Capital.Placement.Program.Data.Validation
{
    public class GenericPersonalInformation
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }

    public class GenericPersonalInformationlValidator<T> : AbstractValidator<T> where T : GenericPersonalInformation
    {
        public GenericPersonalInformationlValidator()
        {
            RuleFor(request => request.FirstName)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .Must(value => !HelperService.ContainsSpecialCharacters(value)).WithMessage("{PropertyName} must not contain special characters");
            RuleFor(request => request.LastName)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .Must(value => !HelperService.ContainsSpecialCharacters(value)).WithMessage("{PropertyName} must not contain special characters");
            RuleFor(request => request.Email)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .EmailAddress().WithMessage("Must be valid email");
        }
    }
}
