namespace ListListApi.Services.Interfaces
{
	public interface IListServices
	{
		Task<ListModel> Get(Guid id);
		Task<IList<ListModel>> GetAll();
		Task<ListModel> Insert(ListModel model);
		Task<ListModel> Update(ListModel model);
		Task<bool> Delete(Guid id);
	}
}
