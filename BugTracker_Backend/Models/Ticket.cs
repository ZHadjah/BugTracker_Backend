
using FluentValidation;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BugTracker_Backend.Models
{
    public class Ticket
    {
        //PK
        public int Id { get; set; }

        //FK
        [DisplayName("Project")]
        public int ProjectId { get; set; }

        [DisplayName("Title")]
        public string Title { get; set; }

        [DisplayName("Description")]
        public string Description { get; set; }

        [DisplayName("Created")]
        [DataType(DataType.Date)]
        public DateTimeOffset Created { get; set; }

        [DataType(DataType.Date)]
        [DisplayName("Updated")]
        public DateTimeOffset? Updated { get; set; }

        [DisplayName("Archived")]
        public bool Archived { get; set; }

        [DisplayName("Ticket Priority")]
        public int TicketPriorityId { get; set; }

        [DisplayName("Ticket Status")]
        public int TicketStatusId { get; set; }

        [DisplayName("Ticket Type")]
        public int TicketTypeId { get; set; }

        [DisplayName("Ticket Owner")]
        public string OwnerUserId { get; set; }

        [DisplayName("Ticket Devleoper")]
        public string DeveloperUserId { get; set; }

        //Navigation Properties
        public Project Project { get; set; }
        public TicketPriority TicketPriority { get; set; }
        public TicketStatus TicketStatus { get; set; }
        public TicketType TicketType { get; set; }
        public BTUser OwnerUser { get; set; }
        public BTUser DeveloperUser { get; set; }
        public ICollection<TicketComment> Comments { get; set; } = new HashSet<TicketComment>();
        public ICollection<TicketAttachment> Attachments { get; set; } = new HashSet<TicketAttachment>();
        public ICollection<Notification> Notifications { get; set; } = new HashSet<Notification>(); 
        public ICollection<TicketHistory> History { get; set; } = new HashSet<TicketHistory>();

    }

    public class TicketValidator : AbstractValidator<Ticket>
    {
        public TicketValidator()
        {
            RuleFor(x => x.Title).NotNull();
            RuleFor(x => x.Title).Length(3, 50);
            RuleFor(x => x.Description).NotNull();
            RuleFor(x => x.Created).NotNull();
        }
    }
}
