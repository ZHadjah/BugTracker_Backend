using System.ComponentModel;

namespace BugTracker_Backend.Models
{
    public class TicketComment
    {
        public int Id { get; set; }
        
        [DisplayName("Member Commit")]
        public string Comment { get; set; }

        [DisplayName("Date")]
        public DateTimeOffset Created { get; set; }

        [DisplayName("Ticket")]
        public int TicketId { get; set; }

        [DisplayName("Team Member")]
        public string UserId { get; set; }


        //Navigation Properties
        public Ticket Ticket { get; set; }
        public BTUser User { get; set; }

    }
}
