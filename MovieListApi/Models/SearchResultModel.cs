using System.Text.Json.Serialization;

namespace MovieListApi.Models
{
    public class SearchResultModel
    {
        public List<MovieFragmentModel> Search { get; set; }
        
        [JsonPropertyName("totalResults")]
        public string TotalResults { get; set; }
        
        public string Response { get; set; }
    }
}