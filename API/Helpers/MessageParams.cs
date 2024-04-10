namespace API.Helpers
{
    public class MessageParams: PaginationParams
    {
        public string Username { get; set; }
        public string Container { get; set; } = "Unread";     //devolver as msgs nao lidas por padrao
    }        
    
}