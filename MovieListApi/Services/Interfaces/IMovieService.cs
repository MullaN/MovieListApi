namespace MovieListApi.Services.Interfaces
{
	public IMovieServices
	{
		Task<MovieModel> Get(string id);
		Task<IList<MovieModel>> GetAll();
		Task<MovieModel> Insert(MovieModel model);
		Task<MovieModel> Update(MovieModel model);
		Task<bool> Delete(string id);
	}
}
