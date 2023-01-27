using FluentValidation;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BugTracker_Backend.Models
{
    public class Notification
    {
        public int Id { get; set; }

        [DisplayName("Ticket")]
        public int TicketId { get; set; }

        [DisplayName("Title")]
        public int Title { get; set; }

        [DisplayName("Message")]
        public int Message { get; set; }

        [DataType(DataType.Date)]
        [DisplayName("Date")]
        public DateTimeOffset Created { get; set; }

        [DisplayName("Recipient")]
        public string RecipientId { get; set; }

        [DisplayName("Sender")]
        public string SenderId { get; set; }

        [DisplayName("Has been viewed")]
        public bool Viewed { get; set; }


        //navigation properties
        public Ticket Ticket { get; set; }
        public BTUser Recipient { get; set; }
        public BTUser Sender { get; set; }
    }


    public class NotificationValidator : AbstractValidator<Notification>
    {
        public NotificationValidator()
        {
            RuleFor(x => x.Title).NotNull();
            RuleFor(x => x.Message).NotNull();
            RuleFor(x => x.SenderId).NotNull();
        }
    }
}
