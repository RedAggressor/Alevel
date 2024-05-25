namespace MVC.Models.Responces
{
    public class ListResponce<T> where T : class
    {
        public IEnumerable<T>? List {  get; set; }
    }
}
