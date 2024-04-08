namespace HomeWork22.Dtos
{
    internal class ResponsPage<T> : PageDto
    { 
        public ResponsPage()
        { }
        
        public int TotalItems => Items.Count;
        
        public int TotalPages 
        {
            get
            {
                return (int)Math.Ceiling((double)TotalItems / PageSize);
            }            
        }

        public List<T> Items { get; set; }
        public ResponsPage(List<T> items, RequestPage request)
        {
            Items = items;
            PageSize = request.PageSize;
            PageNamber = request.PageNamber;
        }
    }
}
