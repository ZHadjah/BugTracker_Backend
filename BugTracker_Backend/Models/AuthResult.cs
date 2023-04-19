namespace BugTracker_Backend.Models
{
    public class AuthResult
    {
        public string Token { get; set; }
        public bool Result { get; set; }
        public BTUser User { get; set; }
        public List<string> Errors { get; set; }
    }
}
