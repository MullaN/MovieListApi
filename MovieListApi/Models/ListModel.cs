namespace MovieListApi.Models
{
    public class ListModel
    {
        public Guid ListId { get; set; }
        public string ListName { get; set; }
        public string ListDescription { get; set; }
        public List<MovieModel> Movies { get; set; }
    }
}