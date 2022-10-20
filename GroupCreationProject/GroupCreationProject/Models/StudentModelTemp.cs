namespace GroupCreationProject.Models
{
    public class StudentModelTemp
    {
        public enum Backgrounds
        {
            Programming,
            Design
            
        }
        public enum Interests
        {
            Management,
            Technical,
            Research,
            UserExperience
        }
        public enum Capabilities
        {
            Servers,
            Routing,
            Frontend,
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public int? GroupId { get; set; }
        public String? Preferences { get; set; }
        public Backgrounds? Background { get; set; }
        public Interests? Interest { get; set; }
        public Capabilities? capability { get; set; }
    }

}
