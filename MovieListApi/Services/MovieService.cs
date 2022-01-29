using System.Collections;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace MovieListApi.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IMapper _mapper;
        private readonly IHttpClientFactory _httpClientFactory;

        public MovieService(IMovieRepository movieRepository, IMapper mapper, IHttpClientFactory httpClientFactory)
        {
            _movieRepository = movieRepository;
            _mapper = mapper;
            _httpClientFactory = httpClientFactory;
        }
        
        public async Task<MovieModel> Get(string id)
        {
            var dbMovie = await _movieRepository.Get(id);
            if (dbMovie != null)
            {
                return _mapper.Map<MovieModel>(dbMovie);
            }
            // else hit OMDB api

            var httpClient = _httpClientFactory.CreateClient("OMDBApi");
            var response = await httpClient.GetAsync(httpClient.BaseAddress + $"&i={id}");
            if (response.IsSuccessStatusCode)
            {
                using var contentStream =
                    await response.Content.ReadAsStreamAsync();

                try
                {
                    var movie = await JsonSerializer.DeserializeAsync
                        <MovieModel>(contentStream);
                    movie.RottenTomatoesScore = movie?.Ratings?.FirstOrDefault(r => r.Source == "Rotten Tomatoes")?.Value;

                    return await Insert(movie);
                }
                catch
                {
                    return null;
                }
            }
            
            return null;
        }

        public async Task<IList<MovieModel>> GetAll()
        {
            var movies = await _movieRepository.GetAll();
            return _mapper.Map<List<MovieModel>>(movies);
        }

        public async Task<IList<MovieModel>> Search(string queryString, bool searchExternal = false)
        {
            if (searchExternal)
            {
                var httpClient = _httpClientFactory.CreateClient("OMDBApi");
                var response = await httpClient.GetAsync(httpClient.BaseAddress + $"&type=movie&s={queryString}");
                var models = new List<MovieModel>();
                if (response.IsSuccessStatusCode)
                {
                    using var contentStream =
                        await response.Content.ReadAsStreamAsync();
                    
                    try
                    {
                        var movieFragments = await JsonSerializer.DeserializeAsync<SearchResultModel>(contentStream);

                        foreach (var fragment in movieFragments.Search)
                        {
                            var movie = await Get(fragment.ImdbId);
                            if (movie != null)
                            {
                                models.Add(movie);
                            }
                        }
                    }
                    catch
                    {
                        return null;
                    }
                }

                return models;
            }

            var entities = await _movieRepository.Search(queryString);
            var topTen = entities.OrderBy(entity => entity.Title.IndexOf(queryString, StringComparison.OrdinalIgnoreCase)).ThenBy(entity => entity.Title.Length).Take(10);
            return _mapper.Map<IList<MovieModel>>(topTen);
        }

        private async Task<MovieModel> Insert(MovieModel model)
        {
            var entity = _mapper.Map<MovieEntity>(model);
            var result = await _movieRepository.Insert(entity);
            return result ? _mapper.Map<MovieModel>(entity) : null;
        }
    }
}