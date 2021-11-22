namespace MovieListApi.Models
{
    public class ListEntryModel
    {
        public Guid ListEntryId { get; set; }
        public Guid ListId { get; set; }
        public string MovieId { get; set; }
    }
}