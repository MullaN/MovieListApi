using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace MovieListApi.Models
{
    public class MovieModel
    {
        [Column("title")]
        public string Title { get; set; }
        [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
        public int Year { get; set; }
        public string Rated { get; set; }
        public string Released { get; set; }
        public string Runtime { get; set; }
        public string Genre { get; set; }
        public string Director { get; set; }
        public string Writer { get; set; }
        public string Actors { get; set; }
        public string Plot { get; set; }
        public string Language { get; set; }
        public string Country { get; set; }
        public string Awards { get; set; }
        public string Poster { get; set; }
        public Rating[] Ratings { get; set; }
        public string RottenTomatoesScore { get; set; }
        [JsonPropertyName("Metascore")]
        [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
        public int MetaScore { get; set; }
        [JsonPropertyName("imdbRating")]
        [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
        public decimal ImdbRating { get; set; }
        [JsonPropertyName("imdbVotes")]
        public string ImdbVotes { get; set; }
        [JsonPropertyName("imdbID")]
        public string ImdbId { get; set; }
        public string Type { get; set; }
        public string BoxOffice { get; set; }
    }

    public class Rating
    {
        public string Source { get; set; }
        public string Value { get; set; }
    }
}