namespace API.Helpers
{
    public class PaginationParams
    {
        private const int MaxPageSize = 50;
        public int PageNumber { get; set; } = 1;
        private int _pageSize = 10;
        
        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = (value > MaxPageSize) ? MaxPageSize : value;    // caso o usuario passe um valor maior que valor maximo estabelecido, retorne o MaxPageSize(50).
        }
    }
}