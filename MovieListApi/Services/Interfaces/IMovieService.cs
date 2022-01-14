namespace MovieListApi.Services.Interfaces
{
	public interface IMovieService
	{
		Task<MovieModel> Get(string id);
		Task<IList<MovieModel>> GetAll();
		Task<IList<MovieModel>> Search(string queryString, bool searchExternal = false);
	}
}
