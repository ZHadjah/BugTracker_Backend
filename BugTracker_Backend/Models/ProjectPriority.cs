using System.ComponentModel;

namespace BugTracker_Backend.Models
{
    public class ProjectPriority
    {
        public int Id { get; set; }

        [DisplayName("Priority Name")]
        public string Name { get; set; }


    }
}
