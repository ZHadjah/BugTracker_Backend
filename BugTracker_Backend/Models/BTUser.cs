using FluentValidation;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bug_tracker_react.Models
{
    public class BTUser : IdentityUser
    {
        [Display(Name = "First Name")]
        public string? FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string? LastName { get; set; }

        [NotMapped]
        public string FullName { get { return $"{FirstName} {LastName}"; } }
    }

    public class BTUserValidator : AbstractValidator<BTUser>
    {
        public BTUserValidator()
        {
            RuleFor(x => x.FirstName).NotNull();
            RuleFor(x => x.FirstName).Length(3, 50);
            RuleFor(x => x.LastName).NotNull();
            RuleFor(x => x.LastName).Length(3, 50);
        }
    }
}

