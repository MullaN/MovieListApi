using Dapper.Contrib.Extensions;

namespace MovieListApi.DataAccess.Entities
{
    [Table("movies")]
    public class MovieEntity
    {
        public string Title { get; set; }
        public int Year { get; set; }
        public string Rated { get; set; }
        public string Released { get; set; }
        public int Runtime { get; set; }
        public string Genre { get; set; }
        public string Director { get; set; }
        public string Writer { get; set; }
        public string Actors { get; set; }
        public string Plot { get; set; }
        public string Language { get; set; }
        public string Country { get; set; }
        public string Awards { get; set; }
        public string Poster { get; set; }
        public string RottenTomatoesScore { get; set; }
        public int MetaScore { get; set; }
        public decimal ImdbRating { get; set; }
        public string ImdbVotes { get; set; }
        [ExplicitKey]
        public string ImdbId { get; set; }
        public string Type { get; set; }
        public string BoxOffice { get; set; }
    }
}