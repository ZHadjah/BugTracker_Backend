using FluentValidation;

namespace BugTracker_Backend.Models.DTOs
{
    public class UserRegistrationRequestDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class UserRegistrationRequestDtoValidator : AbstractValidator<UserRegistrationRequestDto>
    {
        public UserRegistrationRequestDtoValidator()
        {
            RuleFor(x => x.UserName).NotNull();
            RuleFor(x => x.UserName).Length(5, 50);

            RuleFor(x => x.Email).NotNull();
            RuleFor(x => x.Email).Length(5, 50);
            RuleFor(x => x.Email).EmailAddress();

            RuleFor(x => x.Password).NotNull();
            RuleFor(x => x.Password).Length(5, 50);
        }
    }
}
