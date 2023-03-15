using FluentValidation;

namespace BugTracker_Backend.Models.DTOs
{
    public class UserLoginRequestsDto
    {
        public string Email { get; set; }
        public string Password { get; set; }

    }

    public class UserLoginRequestDtoValidator : AbstractValidator<UserLoginRequestsDto>
    {
        public UserLoginRequestDtoValidator()
        {          
            RuleFor(x => x.Email).NotNull();
            RuleFor(x => x.Email).Length(5, 50);
            RuleFor(x => x.Email).EmailAddress();

            RuleFor(x => x.Password).NotNull();
            RuleFor(x => x.Password).Length(5, 50);
        }
    }
}
