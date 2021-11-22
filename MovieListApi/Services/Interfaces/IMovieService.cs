namespace MovieListApi.Services.Interfaces
{
	public interface IMovieService
	{
		Task<MovieModel> Get(string id);
		Task<IList<MovieModel>> GetAll();
	}
}
