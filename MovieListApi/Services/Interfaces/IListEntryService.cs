namespace ListListApi.Services.Interfaces
{
	public interface IListEntryService
	{
		Task<ListEntryModel> Get(Guid id);
		Task<IList<ListEntryModel>> GetAll();
		Task<ListEntryModel> Insert(ListEntryModel model);
		Task<ListEntryModel> Update(ListEntryModel model);
		Task<bool> Delete(Guid id);
	}
}
