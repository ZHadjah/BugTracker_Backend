using System.ComponentModel;

namespace BugTracker_Backend.Models
{
    public class TicketHistory
    {
        public int Id { get; set; }

        [DisplayName("Ticket")]
        public int TicketId { get; set; }

        [DisplayName("Updated Item")]
        public string Property { get; set; }

        [DisplayName("Previous")]
        public string OldValue { get; set; }

        [DisplayName("Current")]
        public string NewValue { get; set; }

        [DisplayName("Date Modified")]
        public DateTimeOffset Created { get; set; }

        [DisplayName("Description of the Change")]
        public string Description { get; set; }

        [DisplayName("Team Member")]
        public string UserId { get; set; }

        //Navigation properties
        public Ticket Ticket { get; set; }
        public BTUser User { get; set; }

    }
}
