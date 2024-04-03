
namespace API.Entities
{
    public class UserLike
    {
        public AppUser SourceUser { get; set; }
        public int SourceUserId { get; set; }
        public AppUser TagerUser { get; set; }
        public int TagerUserId { get; set; }
    }
}