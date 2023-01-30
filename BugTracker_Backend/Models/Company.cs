using System.ComponentModel;

namespace BugTracker_Backend.Models
{
    public class Company
    {
        public int Id { get; set; }

        [DisplayName("Company Name")]
        public string Name { get; set; }

        [DisplayName("Company Description")]
        public string Description { get; set; }

        //Navigation Properties
        public ICollection<BTUser> Members { get; set; }
        public ICollection<Project> Projects { get; set; }
        public ICollection<Invite> Invites { get; set; }

    }
}
