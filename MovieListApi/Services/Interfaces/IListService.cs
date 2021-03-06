namespace ListListApi.Services.Interfaces
{
	public interface IListService
	{
		Task<ListModel> Get(Guid id);
		Task<IList<ListModel>> GetAll();
		Task<ListModel> Insert(ListModel model);
		Task<ListModel> Update(Guid id, ListModel model);
		Task<bool> Delete(Guid id);
	}
}
