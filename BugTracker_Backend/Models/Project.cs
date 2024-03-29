﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using FluentValidation;

namespace BugTracker_Backend.Models
{
    public class Project
    {
        public int Id { get; set; }

        [DisplayName("Company")]
        public int CompanyId { get; set; }

        [DisplayName("Project Name")]
        public string Name { get; set; }

        [DisplayName("Description")]
        public string Description { get; set; }

        [DisplayName("Start Date")]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [DisplayName("End Date")]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }

        [DisplayName("Priority")]
        public int? ProjectPriorityId { get; set; }

        [NotMapped]
        [DataType(DataType.Upload)]
        public IFormFile ImageFormFile { get; set; }

        [DisplayName("File Name")]
        public string? ImageFileName { get; set; }

        public byte[]? ImageFileData { get; set; }

        [DisplayName("File Extension")]
        public string? ImageContentType { get; set; }

        [DisplayName("Archived")]
        public bool? Archived { get; set; }

        //navigation properties
        public Company Company { get; set; }
        public ProjectPriority ProjectPriority { get; set; }
        public ICollection<BTUser> Members { get; set; } = new HashSet<BTUser>();
        public ICollection<Ticket> Tickets { get; set; } = new HashSet<Ticket>();
    }

    public class ProjectValidator : AbstractValidator<Project>
    {
        public ProjectValidator()
        {
            RuleFor(x => x.Name).NotNull();
            RuleFor(x => x.Name).Length(3, 50);

            RuleFor(x => x.Description).NotNull();
        }
    }
}
