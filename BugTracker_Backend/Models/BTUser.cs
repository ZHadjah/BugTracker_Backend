using FluentValidation;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BugTracker_Backend.Models
{
    public class BTUser : IdentityUser
    {
        [Display(Name = "First Name")]
        public string? FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string? LastName { get; set; }

        [NotMapped]
        public string FullName { get { return $"{FirstName} {LastName}"; } }

        [NotMapped]
        [DataType(DataType.Upload)]
        public IFormFile AvatarFormFile { get; set; }

        [DisplayName("Avatar")]
        public string AvatarFileName { get; set; }

        public byte[] AvatarFileData { get; set; }

        [Display(Name = "File Extension")]
        public string AvatarContentType { get; set; }

        public int? CompanyId { get; set; }


        //Navigation Properties
        public Company Company { get; set; }
        public ICollection<Project> Projects { get; set; }
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

