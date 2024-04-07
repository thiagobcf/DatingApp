namespace API.Helpers
{
    public class UserParams: PaginationParams
    {               
        public string CurrentUsername { get; set; }
        public string Gender { get; set; }
        public int MinAge { get; set; } = 18;                        // idade minima permitida 18 anos.
        public int MaxAge { get; set; } = 100;
        public string OrderBy { get; set; } = "lastActive";
    }
}